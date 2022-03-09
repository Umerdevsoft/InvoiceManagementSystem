using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using InvoiceManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace InvoiceManagementSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ApplicationUser> logger;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ILogger<ApplicationUser> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        #region Regiser Section
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
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var ConfirmationLink = Url.Action("Confirm", "Account",
                        new { userid = user.Id, token = token }, Request.Scheme);
                    logger.Log(LogLevel.Warning, ConfirmationLink);
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
        #endregion


        #region Login Section
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

        #endregion


        #region Forget Password Screen
        public IActionResult forgetPassword()
        {
            return View();
        }

        //public async Task<IActionResult> ForgetPassword(string UserName)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    return View(UserName);
        //}

        #endregion

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
