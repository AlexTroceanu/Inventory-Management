﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductsInMemoryRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, CategoryId = 1, Name = "Smartphone", Quantity = 50, Price = 500 },
            new Product { ProductId = 2, CategoryId = 1, Name = "Laptop", Quantity = 30, Price = 800 },
            new Product { ProductId = 3, CategoryId = 2, Name = "T-Shirts", Quantity = 300, Price = 9.49 },
            new Product { ProductId = 4, CategoryId = 2, Name = "Jeans", Quantity = 300, Price = 19.99 },
			new Product { ProductId = 5, CategoryId = 3, Name = "Washing Machine", Quantity = 20, Price = 449.99 },
			new Product { ProductId = 6, CategoryId = 3, Name = "Fridge", Quantity = 30, Price = 700 },
			new Product { ProductId = 7, CategoryId = 4, Name = "Beds", Quantity = 10, Price = 600 },
			new Product { ProductId = 8, CategoryId = 4, Name = "Bookshelves", Quantity = 15, Price = 74.99 },
		};

        private readonly ICategoryRepository categoryRepository;

        public ProductsInMemoryRepository(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void AddProduct(Product product)
        {
            if (_products != null && _products.Count > 0)
            {
                var maxId = _products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            } else
            {
                product.ProductId = 1;
            }

            if (_products == null) _products = new List<Product>();
            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts(bool loadCategory = false)
        {
            if (!loadCategory)
            {
                return _products;
            } else
            {
                if (_products != null && _products.Count > 0)
                {
                    _products.ForEach(x =>
                    {
                        if (x.CategoryId.HasValue)
                            x.Category = categoryRepository.GetCategoryById(x.CategoryId.Value);
                    });
                }

                return _products ?? new List<Product>();
            }
        }

        public Product? GetProductById(int productId, bool loadCategory = false)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                var prod = new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };

                if (loadCategory && prod.CategoryId.HasValue)
                {
                    prod.Category = categoryRepository.GetCategoryById(prod.CategoryId.Value);
                }

                return prod;
            }

            return null;
        }

        public void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return;

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = _products.Where(x => x.CategoryId == categoryId);
            if (products != null)
                return products.ToList();
            else
                return new List<Product>();
        }
    }
}