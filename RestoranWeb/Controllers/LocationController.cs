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
    public class LocationController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public LocationController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            RestoranContext context = new RestoranContext();
            var model = context.Location.ToList();
            return View(model);
        }           
        [HttpGet]
        public ActionResult Details()
        {
            int id =(int) Session["locationId"];
            Location model = unitOfWork.LocationRep.Get(id);
            return View(model);
        }            
        [HttpPost]
        public ActionResult Select(int id)
        {
            Session["locationId"] = id;
            return RedirectToAction("Details");
        }
    }
}