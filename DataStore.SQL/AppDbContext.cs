using CoreEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.SQL
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Fruit", Description = "Beverage" },
                new Category() { CategoryId = 2, Name = "Vegetable", Description = "Bakery" },
                new Category() { CategoryId = 3, Name = "Canned Goods", Description = "Meat" },
                new Category() { CategoryId = 4, Name = "Dairy", Description = "Meat" },
                new Category() { CategoryId = 5, Name = "Meat", Description = "Meat" },
                new Category() { CategoryId = 6, Name = "Seafood", Description = "Meat" },
                new Category() { CategoryId = 7, Name = "Condiments", Description = "Meat" },
                new Category() { CategoryId = 8, Name = "Drink", Description = "Meat" },
                new Category() { CategoryId = 9, Name = "Frozenfood", Description = "Meat" },
                new Category() { CategoryId = 10, Name = "Personal Care", Description = "Meat" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, CategoryId = 1, Name = "Apple", Price = 25.00, Quantity = 100 },
                new Product() { ProductId = 2, CategoryId = 1, Name = "Bananas", Price = 120.00, Quantity = 100 },
                new Product() { ProductId = 3, CategoryId = 1, Name = "Orange", Price = 39.80, Quantity = 100 },

                new Product() { ProductId = 4, CategoryId = 2, Name = "Potatoes", Price = 50.00, Quantity = 100 },
                new Product() { ProductId = 5, CategoryId = 2, Name = "Onions", Price = 100.00, Quantity = 100 },

                new Product() { ProductId = 6, CategoryId = 3, Name = "Century Tuna", Price = 32.00, Quantity = 100 },
                new Product() { ProductId = 7, CategoryId = 3, Name = "San Marino", Price = 35.00, Quantity = 100 },

                new Product() { ProductId = 8, CategoryId = 4, Name = "Butter", Price = 100.00, Quantity = 100 },
                new Product() { ProductId = 9, CategoryId = 4, Name = "Egg", Price = 10.00, Quantity = 100 },

                new Product() { ProductId = 10, CategoryId = 5, Name = "Pork", Price = 150.00, Quantity = 100 },

                new Product() { ProductId = 11, CategoryId = 6, Name = "Shrimp", Price = 500.00, Quantity = 100 },

                new Product() { ProductId = 12, CategoryId = 7, Name = "Pepper", Price = 5.00, Quantity = 100 },

                new Product() { ProductId = 13, CategoryId = 8, Name = "Vitamilk", Price = 33.00, Quantity = 100 },

                new Product() { ProductId = 14, CategoryId = 9, Name = "Hotdog", Price = 85.00, Quantity = 100 },

                new Product() { ProductId = 15, CategoryId = 10, Name = "Shampoo", Price = 333.00, Quantity = 100 },
                new Product() { ProductId = 16, CategoryId = 10, Name = "Dr.Wong Soap", Price = 52.00, Quantity = 100 }
                );
        }

    }
}
