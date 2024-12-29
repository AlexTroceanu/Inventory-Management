using Inventory_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);
            return View(category);
           
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid) 
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
			ViewBag.Action = "edit";
			return View(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category) 
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int categoryID)
        {
            CategoriesRepository.DeleteCategory(categoryID);
            return RedirectToAction(nameof(Index));
        }
    }
}
