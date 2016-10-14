using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;
using RestoranWeb.Models;

namespace RestoranWeb.Controllers
{
    public class SupplierController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public SupplierController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ActionName("Suppliers")]
        public ActionResult SuppliersLocation()
        {
            var cookie = Request.Cookies["Restoran"];
            var marketId = int.Parse(cookie["marketId"]);
            var model = unitOfWork.MarketRep.Get(marketId).Suppliers.ToList();
            return View("SupplierOrder", model);
        }

     

        [HttpGet]
        [ActionName("Order")]
        public ActionResult SupplierProducts(int? id)
        {            
            var cookie = Request.Cookies["Restoran"];
            var marketId = int.Parse(cookie["marketId"]);
            var productSupplier = unitOfWork.MarketRep.Get(marketId).Suppliers.Where(s=>s.SupplierId==id).FirstOrDefault().Products.ToList();
            OrderCreateViewModel model = new OrderCreateViewModel(productSupplier,(int)id);
            return View("SupplierProducts", model);
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = unitOfWork.SupplierRep.GetAll().ToList();
            return View(model);
        }      
    }
}