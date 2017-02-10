using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran;
using RestoranWeb.Models;
using Restoran.Repositories;

namespace RestoranWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public ProductController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var products = unitOfWork.ProductRep.GetAll().ToList();
            return View(products);

        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            model.Units = new SelectList(unitOfWork.UnitRep.GetAll(), "UnitId", "Symbol");
            model.ProductСategories = new SelectList(unitOfWork.ProductCategoryRep.GetAll(), "ProductCategoryId", "Name");
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product();
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.ProductCategory = unitOfWork.ProductCategoryRep.Get(model.ProductCategoryId);
                entity.Unit = unitOfWork.UnitRep.Get(model.UnitId);
                unitOfWork.ProductRep.Add(entity);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var entity = unitOfWork.ProductRep.Get((int)id);
            if (entity == null)
                return RedirectToAction("Index");
            ProductViewModel model = new ProductViewModel();
            model.Id = entity.ProductId;
            model.Name = entity.Name;
            model.Description = entity.Description;
            model.UnitId = entity.UnitId;
            model.ProductCategoryId = entity.ProductCategoryId;
            model.ProductСategories = new SelectList(unitOfWork.ProductCategoryRep.GetAll(), "ProductCategoryId", "Name");
            model.Units = new SelectList(unitOfWork.UnitRep.GetAll(), "UnitId", "Symbol");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = unitOfWork.ProductRep.Get(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.UnitId = model.UnitId;
                    entity.ProductCategoryId = model.ProductCategoryId;
                    unitOfWork.ProductRep.Update(entity);
                    unitOfWork.Save();
                }
            }         
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var entity = unitOfWork.ProductRep.Get((int)id);
            if (entity == null)
                return RedirectToAction("Index");
            return View(entity);
        }
    }
}