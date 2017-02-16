using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;
using RestoranWeb.Models;
using RestoranWeb.Models.SupplierViewModel;
using Restoran;
using RestoranWeb.Models.OrderViewModel;

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
            var suppliers = unitOfWork.MarketRep.Get(marketId).Suppliers;
            SelectList model = new SelectList(suppliers, "SupplierId", "Name");
            return View("SelectSupplier", model);
        }     

        [HttpPost]
        [ActionName("Select")]
        public ActionResult SupplierProducts(int? id)
        {            
            var cookie = Request.Cookies["Restoran"];
            var marketId = int.Parse(cookie["marketId"]);
            var model = new OrderCreateViewModel();
            model.SupplierId = (int)id;
            model.ProductOrdered = unitOfWork.LocationRep.Get(marketId).
                Market.Suppliers
                .Where(x => x.SupplierId == id).FirstOrDefault().
                Products.Select(x => new ProductOrderedViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Unit=x.Product.Unit.Symbol,
                    Value = 0
                }).ToList();
            return View("SupplierProducts", model);
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var entity = unitOfWork.SupplierRep.Get((int)id);
            if (entity == null)
                RedirectToAction("Index");
            return View(entity);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                RedirectToAction("Index");
            var entity = unitOfWork.SupplierRep.Get((int)id);
            if (entity == null)
                return RedirectToAction("Index");
            var model = new SupplierViewModel();
            model.Id = entity.SupplierId;
            model.Name = entity.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = unitOfWork.SupplierRep.Get(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    unitOfWork.SupplierRep.Update(entity);
                    unitOfWork.Save();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(SupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Supplier();
                entity.Name = model.Name;
                unitOfWork.SupplierRep.Add(entity);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = unitOfWork.SupplierRep.GetAll().ToList();
            return View(model);
        }      
      
    }
}