using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using InvoiceManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceManagementSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountsController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    PasswordHash = userViewModel.Password,
                    CompanyName = userViewModel.CompanyName
                };

                var result = await userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Login", "Accounts");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(userViewModel);
        }
        

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
               
                var result = await signInManager.PasswordSignInAsync(loginView.Email, loginView.Password, loginView.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "InvoiceDashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(loginView);
        }

        public IActionResult forgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
