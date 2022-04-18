using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManagementSystem.ViewModels;
using InvoiceManagementSystem.Models;

namespace InvoiceManagementSystem.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly AppDbContext appDbContext;

        public InvoicesController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        #region All Invoices
        public IActionResult AllInvoices()
        {
            return View();
        }
        #endregion

        [HttpGet]
        public IEnumerable<InvoicesViewModels> InvoiceOverviewList()
        {
            var allInvoices = appDbContext.Invoices;
            return allInvoices;

        }

        #region New Invoice
        public IActionResult NewInvoices()
        {
            return View();
        }
        #endregion

        #region SalesPersonList
        [HttpGet]
        public IEnumerable<SalesPersonsViewModel> SalesPersonList()
        {
            var allSp = appDbContext.SalesPerson;
            return allSp;
        }
        #endregion

        #region AddSalesPerson
        [HttpPost]
        public JsonResult AddSalesPerson(SalesPersonsViewModel salesPerson)
        {
            if (salesPerson.Name == null && salesPerson.Email == null && salesPerson.ID == 0)
            {
                return Json("Error");
            }
            if ((salesPerson.Name == null || salesPerson.Email == null) && salesPerson.ID == 0)
            {
                return Json("Error");
            }
            appDbContext.Add<SalesPersonsViewModel>(salesPerson);
            appDbContext.SaveChanges();
            return Json("Sales Person Added Successfully");

        }
        #endregion
        [HttpGet]
        public JsonResult DeleteSalesPerson(SalesPersonsViewModel salesPerson)
        {
            if (salesPerson == null)
            {
                return Json("Error");
            }

            var Person = appDbContext.SalesPerson.Where(x => x.ID == salesPerson.ID).FirstOrDefault();
            appDbContext.SalesPerson.Remove(Person);
            appDbContext.SaveChanges();
            return Json("Sales Person Deleted Successfully");
        }

        [HttpGet]
        public JsonResult Invoice_Auto_Generate_Number()
        {
            var maxValue = appDbContext.Invoices.Max(x => x.InvoiceNumber);
            maxValue++;
            return Json(maxValue);
        }

        [HttpGet]
        public JsonResult Invoice_Manual_Generate_Number_Search(InvoiceNumber obj)
        {
            string num = obj.number;
            if (num == null)
            {
                return Json("");
            }
            if (num == "")
            {
                return Json("");

            }
            int Num = Int32.Parse(num);
            var search = appDbContext.Invoices.Where(x => x.InvoiceNumber == Num).FirstOrDefault();
            if (search != null)
            {
                return Json("Number Already Exist !");
            }
            return Json("Done_");
        }

        [HttpGet]
        public IEnumerable<AmountViewModel> AmountOverviewList()
        {
            var allInvoices = appDbContext.Amounts;
            return allInvoices;

        }

        [HttpGet]
        public IEnumerable<Invoice_Item> Invoice_Items_List()
        {
            var allInvoices = appDbContext.Invoice_Items;
            return allInvoices;

        }

        [HttpPost]
        public int AddInvoice(InvoicesViewModels invoicesViewModel)
        {

            appDbContext.Add<InvoicesViewModels>(invoicesViewModel);
            appDbContext.SaveChanges();

            return invoicesViewModel.InvoiceNumber;
        }

        [HttpPost]
        public int AddInvoiceAmount(AmountViewModel amount)
        {

            appDbContext.Add<AmountViewModel>(amount);
            appDbContext.SaveChanges();
            var sub = 12;
            return sub;
        }

        [HttpPost]
        public int AddInvoice_Item(Invoice_Item invoice_Item)
        {

            appDbContext.Add<Invoice_Item>(invoice_Item);
            appDbContext.SaveChanges();
            var sub1 = 13;
            return sub1;
        }

    }


}
