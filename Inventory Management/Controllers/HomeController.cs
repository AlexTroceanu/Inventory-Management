﻿using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() 
        {
            return View("Index");
        }
      
    }
}
