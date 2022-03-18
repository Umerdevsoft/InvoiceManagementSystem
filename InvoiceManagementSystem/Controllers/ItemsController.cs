using InvoiceManagementSystem.Models;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext appDbContext;

        public ItemsController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        #region Item Main Page

        [HttpGet]

        public IActionResult AllItems()
        {
            var itemsData =  appDbContext.Items;
            return View(itemsData);

        }  
 
            #endregion

            #region Add Items Controller

            [HttpGet]
        public IActionResult AddItems()
        {
            return View();
        }
        [HttpPost]
        public string AddItems(ItemsViewModels itemsViewModels)
        {
            appDbContext.Add<ItemsViewModels>(itemsViewModels);
            appDbContext.SaveChanges();
            return "Item Save Successfully";
        }
       
        #endregion

        #region Edit Items Controller
        public IActionResult EditItems()
        {
            return View();
        }
        #endregion

        #region Overview Items Controller
        public IActionResult ItemOverview()
        {
            return View();
        }
        #endregion

    }
}
