using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using InvoiceManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using InvoiceManagementSystem.Services;


namespace InvoiceManagementSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ApplicationUser> logger;
        private readonly IEmailSender emailSender;
       
        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ILogger<ApplicationUser> logger,IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        #region Regiser Section
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    PasswordHash = userViewModel.Password,
                    CompanyName = userViewModel.CompanyName,
                    FullName = userViewModel.FullName

                };

                var result = await userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var ConfirmationLink = Url.Action("ConfirmEmail", "Accounts",
                        new { email = user.Email, token = token }, Request.Scheme);
                    await emailSender.SendEmailAsync(user.Email, "Test", ConfirmationLink).ConfigureAwait(false);

                    logger.Log(LogLevel.Warning, ConfirmationLink);



                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("ConfirmEmail", "Accounts");

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


        #region ConfirmEmail
       
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            if (email == null || token == null)
            {
                return RedirectToAction("Register", "Accounts");
            }

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"This User ID {email} is invalid";
                return View("Not Found");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }
            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
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
        public async Task<IActionResult> Login(LoginViewModel loginView,string returnurl=null)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(loginView.Email, loginView.Password, loginView.RememberMe, false);

                if (result.Succeeded)
                {
                    //return RedirectToAction(returnurl);
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


        #region ResetPassword
        public IActionResult ResetPassword()
        {

            return View();
        }
        #endregion

        #region ConfirmPasswordReset
        public IActionResult ConfirmPassword()
        {

            return View();
        }
        #endregion

        #region Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Accounts");
        }
        #endregion

    }
}
