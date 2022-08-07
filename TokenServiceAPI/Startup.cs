using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using TokenServiceAPI.Data;

namespace TokenServiceAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name; 
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<IdentityUser>()
                //Configuration store: Clients and resources
                .AddConfigurationStore(options =>
                    options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(Configuration["ConnectionString"],
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                //Operational store: tokens, consents, codes etc
                .AddOperationalStore(options =>
                options.ConfigureDbContext =
                builder => builder.UseSqlServer(Configuration["ConnectionString"],
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeIdentityServerDatabaseTables(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();


        }

        private void InitializeIdentityServerDatabaseTables(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                //temp code to remove and reseed data
                context.Clients.RemoveRange(context.Clients);
                context.IdentityResources.RemoveRange(context.IdentityResources);
                context.ApiResources.RemoveRange(context.ApiResources);
                context.ApiScopes.RemoveRange(context.ApiScopes);
                context.SaveChanges();

                //Seed the data
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients(Config.GetUrls(Configuration)))
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in Config.Apis())
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.GetAllApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.IdentityResources.Any())
                {
                    foreach (var identity in Config.GetIdentityResources())
                    {
                        context.IdentityResources.Add(identity.ToEntity());
                    }
                    context.SaveChanges();
                }

            }
        }
    }
}
