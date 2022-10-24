using API.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feature> Features { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(b => b.Name)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(b => b.Name)
                .IsRequired();
            modelBuilder.Entity<Rating>()
                .Property(r => r.CreateDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}