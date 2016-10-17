using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;
using RestoranWeb.Models.ProductCategory;
using Restoran;

namespace RestoranWeb.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public ProductCategoryController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = unitOfWork.ProductCategoryRep.GetAll().ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var entity = unitOfWork.ProductCategoryRep.Get((int)id);
            if (entity == null)
                return RedirectToAction("Index");
            return View(entity);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                RedirectToAction("Index");
            var entity = unitOfWork.ProductCategoryRep.Get((int)id);
            if (entity == null)
                RedirectToAction("Index");
            var model = new ProductCategoryViewModel();
            model.Id = entity.ProductCategoryId;
            model.Name = entity.Name;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = unitOfWork.ProductCategoryRep.Get(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    unitOfWork.ProductCategoryRep.Update(entity);
                    unitOfWork.Save();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductCategoryViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ProductCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new ProductCategory();
                entity.Name = model.Name;
                unitOfWork.ProductCategoryRep.Add(entity);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }
    }
}