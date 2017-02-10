using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;
using RestoranWeb.Models.MarketViewModel;
using Restoran;
using RestoranWeb.Infrastructure;

namespace RestoranWeb.Controllers
{
    public class MarketController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public MarketController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = unitOfWork.MarketRep.GetAll().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(MarketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Market();
                entity.Name = model.Name;
                unitOfWork.MarketRep.Add(entity);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var model = unitOfWork.MarketRep.Get((int)id);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var entity = unitOfWork.MarketRep.Get((int)id);
            if (entity == null)
                return RedirectToAction("Index");
            var model = new MarketViewModel();
            model.Id = entity.MarketId;
            model.Name = entity.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MarketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = unitOfWork.MarketRep.Get(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    unitOfWork.MarketRep.Update(entity);
                    unitOfWork.Save();
                }
            }
            return RedirectToAction("Index");
        }

        [ActionName("Suppliers")]
        [HttpGet]
        public ActionResult MarketSupplier(int id)
        {
            var model = new MarketEditViewModel();
            model.Id = id;
            var supplier = unitOfWork.SupplierRep.GetAll().ToList();
            model.MarketSupplier = supplier.Where(x => x.Markets.Any(p => p.MarketId == id)).ToList();
            if (model.MarketSupplier == null)
            {
                model.NoMarketSupplier = supplier;
            }
            else
            {
                model.NoMarketSupplier = supplier.Where(x => !x.Markets.Any(p => p.MarketId == id)).ToList();
            }
            TempData["marketsupplier"] = model;
            return View("Suppliers", model);
        }

        [AjaxOnly]
        public ActionResult AddSupplier(int supId)
        {
            var model = (MarketEditViewModel)TempData["marketsupplier"];
            var supplier = model.NoMarketSupplier.Where(x => x.SupplierId == supId).FirstOrDefault();
            if (supplier != null)
            {
                model.MarketSupplier.Add(supplier);
                model.NoMarketSupplier.Remove(supplier);
            }
            TempData["marketsupplier"] = model;
            return PartialView("SuppliersEdit", model);
        }

        [AjaxOnly]
        public ActionResult RemoveSupplier(int supId)
        {
            var model = (MarketEditViewModel)TempData["marketsupplier"];
            var supplier = model.MarketSupplier.Where(x => x.SupplierId == supId).FirstOrDefault();
            if (supplier != null)
            {
                model.NoMarketSupplier.Add(supplier);
                model.MarketSupplier.Remove(supplier);
               
            }
            TempData["marketsupplier"] = model;
            return PartialView("SuppliersEdit", model);
        }

        [HttpPost]
        public ActionResult EditSupplier(MarketEditViewModel model)
        {
            var editmodel = unitOfWork.MarketRep.Get(model.Id);
            var editModelSupplier = editmodel.Suppliers.ToList();
            foreach (var supplier in editModelSupplier)
            {
                editmodel.Suppliers.Remove(supplier);
            }
            foreach (var supplier in model.MarketSupplier)
            {
                var sup = unitOfWork.SupplierRep.Get(supplier.SupplierId);
                editmodel.Suppliers.Add(sup);
            }
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}