<<<<<<< HEAD
﻿using Inventory_Management.Models;
=======
﻿using CoreBusiness;
>>>>>>> 6979bea (login)
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Inventory_Management.ViewModels.Validations;

namespace Inventory_Management.ViewModels
{
	public class SalesViewModel
	{
		public int SelectedCategoryId { get; set; }
		public IEnumerable<Category> Categories { get; set; } = new List<Category>();
		public int SelectedProductId { get; set; }

		[Display(Name="Quantity")]
		[Range(1,int.MaxValue)]
		[SalesViewModel_EnsureProperQuantity]
		public int QuantityToSell { get; set; }
	}
}
