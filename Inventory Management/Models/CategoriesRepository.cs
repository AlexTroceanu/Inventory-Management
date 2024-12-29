﻿namespace Inventory_Management.Models
{
	public static class CategoriesRepository
	{
		private static List<Category> _categories = new List<Category>()
		{
			new Category { CategoryId = 1, Name = "Electronics", Description = "Modern gadgets for communication and entertainment" },
			new Category { CategoryId = 2, Name = "Clothing", Description = "Apparel and accessories for personal style" },
			new Category { CategoryId = 3, Name = "Home Appliances", Description = "Tools for household chores and convenience" },
			new Category { CategoryId = 4, Name = "Furniture", Description = "Functional pieces for comfortable living spaces" },
			new Category { CategoryId = 5, Name = "Groceries", Description = "Everyday food and household essentials" }
		};

		public static void AddCategory(Category category)
		{
			if(_categories != null && _categories.Count > 0)
			{
                var maxId = _categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
			else
			{
                category.CategoryId = 1;
            }
			if(_categories == null) _categories = new List<Category>();
			_categories.Add(category);
		}

		public static List<Category> GetCategories() => _categories;

		public static Category? GetCategoryById(int categoryId)
		{
			var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
			if (category != null)
			{
				return new Category
				{
					CategoryId = category.CategoryId,
					Name = category.Name,
					Description = category.Description,
				};
			}

			return null;
		}

		public static void UpdateCategory(int categoryId, Category category)
		{
			if (categoryId != category.CategoryId) return;

			var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
			}
		}

		public static void DeleteCategory(int categoryId)
		{
			var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
			if (category != null)
			{
				_categories.Remove(category);
			}
		}

	}
}