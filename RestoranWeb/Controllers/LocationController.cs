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
      private  HttpCookie cookie = new HttpCookie("Restoran");
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
                 
        [HttpPost]
        [ActionName("Select")]
        public ActionResult Menu(int? id)
        {           
            cookie["locationId"] = id.ToString();
            Response.Cookies.Add(cookie);
            Location model = unitOfWork.LocationRep.Get((int)id);
            return View("Details",model);
        }                  
    }
}