using Microsoft.AspNetCore.Mvc;
using Inventory_Management.ViewModels;
<<<<<<< HEAD
using Inventory_Management.Models;

namespace Inventory_Management.Controllers
{
    public class TransactionsController : Controller
    {
=======
using CoreBusiness;
using UseCases;
using Microsoft.AspNetCore.Authorization;

namespace Inventory_Management.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionsUseCase searchTransactionsUseCase;

        public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
        {
            this.searchTransactionsUseCase = searchTransactionsUseCase;
        }

>>>>>>> 6979bea (login)
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
<<<<<<< HEAD
            var transactions = TransactionsRepository.Search(
                 transactionsViewModel.SellerName ?? string.Empty,
                 transactionsViewModel.StartDate,
                 transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions;

            return View("Index" ,transactionsViewModel);
=======
            var transactions = searchTransactionsUseCase.Execute(
                transactionsViewModel.SellerName ?? string.Empty,
                transactionsViewModel.StartDate,
                transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions;

            return View("Index", transactionsViewModel);
>>>>>>> 6979bea (login)
        }
    }
}
