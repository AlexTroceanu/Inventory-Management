using Inventory_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionsRepository.GetByDayAndSeller(userName, DateTime.Now);

            return View(transactions);
        }
    }
}