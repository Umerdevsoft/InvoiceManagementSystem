using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Controllers
{
    public class InvoicesController : Controller
    {
        #region All Invoices
        public IActionResult AllInvoices()
        {
            return View();
        }
        #endregion


        #region New Invoice
        public IActionResult NewInvoices()
        {
            return View();
        }
        #endregion

        public IActionResult SalesPersons()
        {
            return View();
        }

    }
}
