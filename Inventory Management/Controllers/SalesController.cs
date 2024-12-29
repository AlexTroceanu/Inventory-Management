<<<<<<< HEAD
﻿using Inventory_Management.Models;
using Inventory_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productId)
        {
            var product = ProductsRepository.GetProductById(productId);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel) 
        { 
            if(ModelState.IsValid)
            {
                var prod = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                if(prod != null)
                {
                    TransactionsRepository.Add(
                        "Seller1",
                        salesViewModel.SelectedProductId,
                        prod.Name,
                        prod.Price.HasValue ? prod.Price.Value : 0,
                        prod.Quantity.HasValue ? prod.Quantity.Value : 0,
                        salesViewModel.QuantityToSell);

                    prod.Quantity -= salesViewModel.QuantityToSell;
                    ProductsRepository.UpdateProduct(salesViewModel.SelectedProductId, prod);
                }

            }
            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = CategoriesRepository.GetCategories();

            return View("Index", salesViewModel);
        }
    }
}
=======
﻿using CoreBusiness;
using Inventory_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases;
using UseCases;
using Microsoft.AspNetCore.Authorization;
using UseCases.ProductsUseCases;

namespace Inventory_Management.Controllers
{
	[Authorize(Policy = "Sellers")]
	public class SalesController : Controller
    {
            private readonly IViewCategoriesUseCase viewCategoriesUseCase;
            private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
            private readonly ISellProductUseCase sellProductUseCase;
		private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;

		public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,
                IViewSelectedProductUseCase viewSelectedProductUseCase,
                ISellProductUseCase sellProductUseCase,
                IViewProductsInCategoryUseCase viewProductsInCategoryUseCase)
            {
                this.viewCategoriesUseCase = viewCategoriesUseCase;
                this.viewSelectedProductUseCase = viewSelectedProductUseCase;
                this.sellProductUseCase = sellProductUseCase;
			    this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
		}

            public IActionResult Index()
            {
                var salesViewModel = new SalesViewModel
                {
                    Categories = viewCategoriesUseCase.Execute()
                };
                return View(salesViewModel);
            }

            public IActionResult SellProductPartial(int productId)
            {
                var product = viewSelectedProductUseCase.Execute(productId);
                return PartialView("_SellProduct", product);
            }

            public IActionResult Sell(SalesViewModel salesViewModel)
            {
                if (ModelState.IsValid)
                {
                    // Sell the product
                    sellProductUseCase.Execute(
                        "seller1",
                        salesViewModel.SelectedProductId,
                        salesViewModel.QuantityToSell);
                }

                var product = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);
                salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
                salesViewModel.Categories = viewCategoriesUseCase.Execute();

                return View("Index", salesViewModel);
            }
		    public IActionResult ProductsByCategoryPartial(int categoryId)
		    {
			    var products = viewProductsInCategoryUseCase.Execute(categoryId);

			    return PartialView("_Products", products);
		    }
	    }
    }
>>>>>>> 6979bea (login)
