using CartApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CartService.DAL
{
    public class CartAppDbContext : DbContext
    {
        public DbSet<ItemDAL> Items { get; set; }
        public DbSet<CartItemDAL> ShoppingCartItems { get; set; }

        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={Environment.CurrentDirectory + @"\ShoppingCart.db"}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItemDAL>().HasKey(sc => new { sc.CartId, sc.ItemId });
            modelBuilder.Entity<ItemDAL>().HasData(
                    new ItemDAL
                     {
                         ItemId = 1,
                         Name = "iPhone 12",
                         Price = 50000,
                         ImageUrl = "https://picsum.photos/200/300"
                    },
                    new ItemDAL
                    {
                        ItemId = 2,
                        Name = "HP Laptop",
                        Price = 50000,
                        ImageUrl = "https://picsum.photos/200/300"
                    },
                    new ItemDAL
                     {
                        ItemId = 3,
                        Name = "Samsung S22 Ultra",
                        Price = 84000,
                        ImageUrl = "https://picsum.photos/200/300"
                    }

            );
        }
    }
}