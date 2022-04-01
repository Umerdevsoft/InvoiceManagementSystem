using InvoiceManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InvoiceManagementSystem.Controllers
{
    //[Authorize]
    public class InvoiceDashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager1;
        private readonly AppDbContext AppDbContext;
        public InvoiceDashboardController(UserManager<ApplicationUser> userManager,AppDbContext appDbContext)
        {
            this.userManager1 = userManager;
            this.AppDbContext = appDbContext;
        }
        public IActionResult Dashboard()
        {
            
            return View();  
        }

        
       




    }
}
