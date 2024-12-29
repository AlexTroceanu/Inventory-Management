using Inventory_Management.Models;
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
