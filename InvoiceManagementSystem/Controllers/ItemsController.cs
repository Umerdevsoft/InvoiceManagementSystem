using InvoiceManagementSystem.Models;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

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
        
            return View();
        }

        //[HttpPost]
        //public IActionResult AllItems(ItemsViewModels itemsViewModels)
        //{
        //    string[] ids = itemsViewModels["ID"].Split(new char[] { ',' });

        //    foreach (string id in ids)
        //    {
        //        var item = appDbContext.Items.Find(int.Parse(id));
        //        appDbContext.Items.Remove(item);
        //        appDbContext.SaveChanges();
        //    }
        //    return View(itemsViewModels);
        //}

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
        [HttpGet]
        public JsonResult EditItems(ItemsViewModels objUpdate)
        {
            var item = appDbContext.Items.Find(objUpdate.Item_ID);
            return Json(item);
        }

        [HttpPost]
        public string EditItems_Post(ItemsViewModels objUpdatePost)
        {
            var item = appDbContext.Items.Update(objUpdatePost);
            appDbContext.SaveChanges();
            return "Item Updated successfully";
        }
        #endregion

        #region Overview Items Controller
        [HttpGet]
        public IActionResult ItemOverview()
        {
            return View();
        }

        #endregion

        #region ItemOverviewList
        [HttpGet]
        public IEnumerable<ItemsViewModels> ItemOverviewList()
        {
            var allItems = appDbContext.Items;
            return allItems;
            //return View();
        }
        #endregion  

        #region ItemDelete
        [HttpPost]
        public JsonResult ItemDelete(ItemsViewModels objDelete)
        {
            var item = appDbContext.Items.Find(objDelete.Item_ID);
            appDbContext.Items.Remove(item);
            appDbContext.SaveChanges();
            var obj1 = objDelete.Item_ID;
            return Json(obj1);

            //return View();
        }

        [HttpPost]
        public JsonResult ItemDeleteList(ItemsViewModels objDelete1)
        {
            if (objDelete1 == null)
            {
                return Json("Something went Wrong, Plz Try Again");
            }
            var item = appDbContext.Items.Find(objDelete1.Item_ID);
            appDbContext.Items.Remove(item);
            appDbContext.SaveChanges();
            return Json("Items Deleted Successfully");
        }

        #endregion


    }
}
