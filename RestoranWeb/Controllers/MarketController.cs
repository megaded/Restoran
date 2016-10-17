using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;
using RestoranWeb.Models.MarketViewModel;
using Restoran;

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
    }
}