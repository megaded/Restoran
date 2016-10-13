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
        public ActionResult SuppliersLocation(int id)
        {
          
            var model = unitOfWork.MarketRep.Get(id).Suppliers.ToList();
            return View("SupplierOrder", model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = unitOfWork.SupplierRep.Get(id).Products;
            OrderCreateViewModel model = new OrderCreateViewModel(product);
            TempData["supplierId"] = id;
            model.Products = unitOfWork.SupplierRep.Get(id).Products;
            return View("SupplierOrder", model);
        }

        [HttpGet]
        [ActionName("Order")]
        public ActionResult SupplierProduct(int? id)
        {
            if(Session["locationId"]==null)
                return RedirectToAction("Index", "Location");
            if (id == null)
                return RedirectToAction("SuppliersLocation");
            var locationId = (int)Session["locationId"];

            return View();
        }

        public ActionResult Index(int id)
        {
            var marketId = unitOfWork.LocationRep.Get(id).MarketId;
            var model = unitOfWork.MarketRep.Get(marketId).Suppliers.ToList();
            return View("SupplierOrder",model);
        }
    }
}