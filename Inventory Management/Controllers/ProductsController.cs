<<<<<<< HEAD
﻿using Inventory_Management.Models;
using Inventory_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }

=======
﻿using CoreBusiness;
using Inventory_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases;

namespace Inventory_Management.Controllers
{
	[Authorize(Policy = "Inventory")]
	public class ProductsController : Controller
    {
        private readonly IAddProductUseCase addProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IViewProductsUseCase viewProductsUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;

        public ProductsController(
            IAddProductUseCase addProductUseCase,
            IEditProductUseCase editProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            IViewProductsUseCase viewProductsUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase)
        {
            this.addProductUseCase = addProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.viewProductsUseCase = viewProductsUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
        }

        public IActionResult Index()
        {
            var products = viewProductsUseCase.Execute(loadCategory: true);
            return View(products);
        }
>>>>>>> 6979bea (login)
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
<<<<<<< HEAD
            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
=======

            var productViewModel = new ProductViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
>>>>>>> 6979bea (login)
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
<<<<<<< HEAD
       {
            if(ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
			ViewBag.Action = "add";
			productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
       }

        [HttpGet]
        public IActionResult Edit(int id)
        {
			ViewBag.Action = "edit";
			var productViewModel = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id)??new Product(),
            Categories = CategoriesRepository.GetCategories()
            };
=======
        {
            if (ModelState.IsValid)
            {
                addProductUseCase.Execute(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            var productViewModel = new ProductViewModel
            {
                Product = viewSelectedProductUseCase.Execute(id) ?? new Product(),
                Categories = viewCategoriesUseCase.Execute()
            };

>>>>>>> 6979bea (login)
            return View(productViewModel);
        }

        [HttpPost]
<<<<<<< HEAD
        public IActionResult Edit(ProductViewModel productViewModel) 
        {

            if(ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
			ViewBag.Action = "edit";
			productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = ProductsRepository.GetProductsByCategoryId(categoryId);

            return PartialView("_Products", products);
        }

=======
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                editProductUseCase.Execute(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }
>>>>>>> 6979bea (login)
    }
}
