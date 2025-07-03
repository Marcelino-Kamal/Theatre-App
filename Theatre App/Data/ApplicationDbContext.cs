using Microsoft.EntityFrameworkCore;
using Theatre_App.Models;

namespace Theatre_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>().HasData(
                    new Roles { Id = 1, Name = "admin" },
                    new Roles { Id = 2, Name = "user" }
            );
           
            modelBuilder.Entity<Catalogue>().HasData(
                    new Catalogue { Id = 1, Name = "Customs" },
                    new Catalogue { Id = 2, Name = "Props" }
            );
        }
    }
}
