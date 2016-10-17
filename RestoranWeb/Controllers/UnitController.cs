using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;
using RestoranWeb.Models.UnitViewModel;
using Restoran;

namespace RestoranWeb.Controllers
{
    public class UnitController : Controller
    {
        private UnitOfWork unitOfWork;
        public UnitController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var model = unitOfWork.UnitRep.GetAll().ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                Unit entity = new Unit();
                entity.Name = model.Name;
                entity.Symbol = model.Symbol;
                unitOfWork.UnitRep.Add(entity);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var model = unitOfWork.UnitRep.Get((int)id);
            if(model==null)
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var entity = unitOfWork.UnitRep.Get((int)id);
            if (entity == null)
                return RedirectToAction("Index");
            var model = new UnitViewModel();
            model.Id = entity.UnitId;
            model.Name = entity.Name;
            model.Symbol = entity.Symbol;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = unitOfWork.UnitRep.Get(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Symbol = model.Symbol;
                    unitOfWork.UnitRep.Update(entity);
                    unitOfWork.Save();
                }
            }
            return RedirectToAction("Index");
        }
    }
}