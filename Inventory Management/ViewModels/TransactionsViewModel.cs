using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using Inventory_Management.Models;
=======
using CoreBusiness;
>>>>>>> 6979bea (login)

namespace Inventory_Management.ViewModels
{
    public class TransactionsViewModel  
    {
        [Display(Name = "Seller Name")]
        public string? SellerName { get; set; }

        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
