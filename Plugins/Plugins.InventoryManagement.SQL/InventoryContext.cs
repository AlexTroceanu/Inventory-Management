<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;

namespace Plugins.InventoryManagement.SQL
{
    public class InventoryContext : DbContext
    {
        
    }
=======
﻿using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Plugins.DataStore.SQL
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options): base(options)
        {
        }

        public DbSet <Category> Categories {get; set;}
        public DbSet <Product> Products { get; set;}
        public DbSet <Transaction> Transactions { get; set;}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>()
				.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId);

			// seeding data

			modelBuilder.Entity<Category>().HasData(
				 new Category { CategoryId = 1, Name = "Electronics", Description = "Modern gadgets for communication and entertainment" },
				 new Category { CategoryId = 2, Name = "Clothing", Description = "Apparel and accessories for personal style" },
				 new Category { CategoryId = 3, Name = "Home Appliances", Description = "Tools for household chores and convenience" },
				 new Category { CategoryId = 4, Name = "Furniture", Description = "Functional pieces for comfortable living spaces" },
				 new Category { CategoryId = 5, Name = "Groceries", Description = "Everyday food and household essentials" }
			 );

			modelBuilder.Entity<Product>().HasData(
				new Product { ProductId = 1, CategoryId = 1, Name = "Smartphone", Quantity = 50, Price = 500 },
				new Product { ProductId = 2, CategoryId = 1, Name = "Laptop", Quantity = 30, Price = 800 },
				new Product { ProductId = 3, CategoryId = 2, Name = "T-Shirts", Quantity = 300, Price = 9.49 },
				new Product { ProductId = 4, CategoryId = 2, Name = "Jeans", Quantity = 300, Price = 19.99 },
				new Product { ProductId = 5, CategoryId = 3, Name = "Washing Machine", Quantity = 20, Price = 449.99 },
				new Product { ProductId = 6, CategoryId = 3, Name = "Fridge", Quantity = 30, Price = 700 },
				new Product { ProductId = 7, CategoryId = 4, Name = "Beds", Quantity = 10, Price = 600 },
				new Product { ProductId = 8, CategoryId = 4, Name = "Bookshelves", Quantity = 15, Price = 74.99 }
			);

		}
	}
>>>>>>> 6979bea (login)
}
