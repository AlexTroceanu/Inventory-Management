<<<<<<< HEAD
﻿using Inventory_Management.Models;
=======
﻿using UseCases;
>>>>>>> 6979bea (login)
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
<<<<<<< HEAD
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionsRepository.GetByDayAndSeller(userName, DateTime.Now);
=======
        private readonly IGetTodayTransactionsUseCase getTodayTransactionsUseCase;

        public TransactionsViewComponent(IGetTodayTransactionsUseCase getTodayTransactionsUseCase)
        {
            this.getTodayTransactionsUseCase = getTodayTransactionsUseCase;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var transactions = getTodayTransactionsUseCase.Execute(userName);
>>>>>>> 6979bea (login)

            return View(transactions);
        }
    }
}