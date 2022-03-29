using InvoiceManagementSystem.Models;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Controllers
{
    public class OrganizationProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        public OrganizationProfileController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult SettingProfile()
        {
            return View();
        }



    }
}
