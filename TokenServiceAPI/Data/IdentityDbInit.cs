using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenServiceAPI.Data
{
    public static class IdentityDbInit
    {
        private static UserManager<IdentityUser> _userManager;
        //This example just creates an Administrator role and one Admin users
        public static async Task Initialize(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            //create database schema if none exists
            context.Database.Migrate();
            //If there is already an Administrator role, abort
            //  if (context.Roles.Any(r => r.Name == "Administrator")) return;

            //Create the Administartor Role
            // await roleManager.CreateAsync(new IdentityRole("Administrator"));
            if (context.Users.Any(r => r.UserName == "me@myemail.com")) return;
            //Create the default Admin account and apply the Administrator role
            string user = "me@myemail.com";
            string password = "P@ssword1";
            await _userManager.CreateAsync(new IdentityUser { UserName = user, Email = user, EmailConfirmed = true }, password);
            //   await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user), "Administrator");
        }
    }
}
