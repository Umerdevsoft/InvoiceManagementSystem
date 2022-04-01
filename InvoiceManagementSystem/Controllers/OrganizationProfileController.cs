﻿using InvoiceManagementSystem.Models;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Controllers
{
    public class OrganizationProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext AppDbContext;

        public OrganizationProfileController(AppDbContext appDbContext,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.AppDbContext = appDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult SettingProfile()
        {
            return View();
        }

      
        //public async Task<IActionResult> SettingProfile(ApplicationUser applicationUser)
        //{
        //    var user = new ApplicationUser
        //    {
        //        FullName = applicationUser.FullName,
        //        CompanyName = applicationUser.CompanyName,
        //        PasswordHash = applicationUser.PasswordHash
        //    };
            

        //    return View(user);
        //}





    }
}
