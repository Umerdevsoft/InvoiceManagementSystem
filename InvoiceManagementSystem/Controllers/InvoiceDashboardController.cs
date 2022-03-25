using InvoiceManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Controllers
{
    public class InvoiceDashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager1;
        public InvoiceDashboardController(UserManager<ApplicationUser> userManager)
        {
            this.userManager1 = userManager;
        }
        public IActionResult Dashboard()
        { 
            ViewBag.CompanyName = userManager1.GetUserName(HttpContext.User);
            return View();  
        }
    }
}
