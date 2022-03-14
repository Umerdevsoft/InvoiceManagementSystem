using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Controllers
{
    public class ItemsController : Controller
    {

        #region Item Main Page
        public IActionResult AllItems()
        {
            return View();
        }

        #endregion

        #region Add Items Controller
        public IActionResult AddItems()
        {
            return View();
        }
        #endregion

        #region Edit Items Controller
        public IActionResult EditItems()
        {
            return View();
        }
        #endregion


    }
}
