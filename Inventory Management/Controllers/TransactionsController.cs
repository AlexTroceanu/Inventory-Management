using Microsoft.AspNetCore.Mvc;
using Inventory_Management.ViewModels;
using Inventory_Management.Models;

namespace Inventory_Management.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            var transactions = TransactionsRepository.Search(
                 transactionsViewModel.SellerName ?? string.Empty,
                 transactionsViewModel.StartDate,
                 transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions;

            return View("Index" ,transactionsViewModel);
        }
    }
}
