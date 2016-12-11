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
            var model = unitOfWork.LocationRep.GetAll().ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult List()
        {
            var model = unitOfWork.LocationRep.GetAll().ToList();
            return View(model);
        }                 
        [HttpPost]
        public ActionResult Menu(int? id)
        {
            HttpCookie cookie = new HttpCookie("Restoran");
            Location model = unitOfWork.LocationRep.Get((int)id);                        
            cookie["locationId"] = id.ToString();
            cookie["marketId"] = model.MarketId.ToString();
            Response.Cookies.Add(cookie);
            return View("Details",model);
        }                  
    }
}