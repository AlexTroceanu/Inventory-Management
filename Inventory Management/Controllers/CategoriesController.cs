<<<<<<< HEAD
﻿using Inventory_Management.Models;
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

=======
﻿using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases;

namespace Inventory_Management.Controllers
{
    [Authorize(Policy ="Inventory")]
    public class CategoriesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;
        private readonly IEditCategoryUseCase editCategoryUseCase;
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IDeleteCategoryUseCase deleteCategoryUseCase;

        public CategoriesController(
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,
            IEditCategoryUseCase editCategoryUseCase,
            IAddCategoryUseCase addCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            this.editCategoryUseCase = editCategoryUseCase;
            this.addCategoryUseCase = addCategoryUseCase;
            this.deleteCategoryUseCase = deleteCategoryUseCase;
        }

        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();
            return View(categories);
        }
>>>>>>> 6979bea (login)
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";
<<<<<<< HEAD
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);
            return View(category);
           
=======

            var category = viewSelectedCategoryUseCase.Execute(id.HasValue ? id.Value : 0);

            return View(category);
>>>>>>> 6979bea (login)
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
<<<<<<< HEAD
            if(ModelState.IsValid) 
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
			ViewBag.Action = "edit";
			return View(category);
        }

=======
            if (ModelState.IsValid)
            {
                editCategoryUseCase.Execute(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            return View(category);
        }
>>>>>>> 6979bea (login)
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
<<<<<<< HEAD
=======

>>>>>>> 6979bea (login)
            return View();
        }

        [HttpPost]
<<<<<<< HEAD
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
=======
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                addCategoryUseCase.Execute(category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            return View(category);
        }
        
        public IActionResult Delete(int categoryId)
        {
            deleteCategoryUseCase.Execute(categoryId);
            return RedirectToAction(nameof(Index));
        }

    }
}
>>>>>>> 6979bea (login)
