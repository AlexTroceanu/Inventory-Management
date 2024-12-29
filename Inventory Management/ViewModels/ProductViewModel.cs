<<<<<<< HEAD
﻿using Inventory_Management.Models;
=======
﻿using CoreBusiness;
>>>>>>> 6979bea (login)

namespace Inventory_Management.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Product Product { get; set; } = new Product();
    }
}
