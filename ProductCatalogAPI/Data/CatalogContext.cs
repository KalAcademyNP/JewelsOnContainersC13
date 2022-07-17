using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;

namespace ProductCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        { }

        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> Catalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogType>(e =>
            {
                e.Property(t => t.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogBrand>(e =>
            {
                e.Property(t => t.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(t => t.Brand)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogItem>(e =>
            {
                e.Property(t => t.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(t => t.Price)
                    .IsRequired();

                e.HasOne(t => t.CatalogBrand)
                    .WithMany()
                    .HasForeignKey(t => t.CatalogBrandId);

                e.HasOne(t => t.CatalogType)
                    .WithMany()
                    .HasForeignKey(t => t.CatalogTypeId);
            });
        }

    }
}
