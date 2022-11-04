using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .Property(c => c.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Product>().Property(p => p.CreateDate).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.UpdateDate).ValueGeneratedOnAddOrUpdate();
        }
    }
}