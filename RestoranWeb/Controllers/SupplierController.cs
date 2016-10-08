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
        public ActionResult Details(int id)
        {
            var product = unitOfWork.SupplierRep.Get(id).Products;
            OrderCreateViewModel model = new OrderCreateViewModel(product);
            TempData["supplierId"] = id;
            model.Products = unitOfWork.SupplierRep.Get(id).Products;
            return View("SupplierOrder", model);
        }
        
        [HttpGet]
        public ActionResult Products(int id)
        {
            var product = unitOfWork.SupplierRep.Get(id).Products;
            OrderCreateViewModel model = new OrderCreateViewModel(product);
            TempData["supplierId"] = id;
            model.Products = unitOfWork.SupplierRep.Get(id).Products;
            return View(model);
        }
    }
}