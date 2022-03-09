using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult AllCustomers()
        {
            return View();
        }
    }
}
