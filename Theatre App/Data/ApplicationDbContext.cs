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
            modelBuilder.Entity<Users>().HasData(
                    new Users { Id = Guid.Parse("d1c1c31e-1234-4fae-8c1c-abcdef123456"), Name = "Marco", PhoneNumber = "01282771887", Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=" }

            );
            modelBuilder.Entity<Catalogue>().HasData(
                    new Catalogue { Id = 1, Name = "Customs" },
                    new Catalogue { Id = 2, Name = "Props" }
            );

            modelBuilder.Entity<Items>().HasData(
                new Items
                {
                    Id = Guid.Parse("d1c2c31e-1234-4fae-8c1c-abcdef123456"),
                    Name = "Swords",
                    Catalogue_Id = 2,
                    Description = "7aga bt3wr",
                    inStock = true,
                    Price = 100,
                    Quantity = 9,
                    ImgUrl = "url"
                },
                new Items
                {
                    Id = Guid.Parse("d2c1c31e-1234-4fae-8c1c-abcdef123456"),
                    Name = "Sticks",
                    Catalogue_Id = 2,
                    Description = "7aga 5shb",
                    inStock = true,
                    Price = 100,
                    Quantity = 9,
                    ImgUrl = "url"
                }
             );

            modelBuilder.Entity<Orders>().HasData(
               new Orders
               {
                   Id = Guid.Parse("d1c1c31e-1351-4fae-8c1c-abcdef123456"),
                   EndDate = new DateTime(2025, 6, 10),
                   IsApproved = false,
                   IsPaid = false,
                   StartDate = new DateTime(2025, 6, 5),
                   User_Id = Guid.Parse("d1c1c31e-1234-4fae-8c1c-abcdef123456")

               },
              new Orders
              {
                  Id = Guid.Parse("d1c1c99e-1351-4fae-8c1c-abcdef123456"),
                  EndDate = new DateTime(2025, 6, 7),
                  IsApproved = false,
                  IsPaid = false,
                  StartDate = new DateTime(2025, 6, 3),
                  User_Id = Guid.Parse("d1c1c31e-1234-4fae-8c1c-abcdef123456")
              }
            );
        }
    }
}
