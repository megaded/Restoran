using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;

namespace RestoranWeb.Controllers
{
    public class ProductStorageController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public ProductStorageController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
           int warehouseId = (int)Session["locationId"];
            if (warehouseId==0)
            {
                return RedirectToAction("Index", "Location");
            }
            var product = unitOfWork.LocationRep.Get(warehouseId).Products;
            return View(product);
        }

        public ActionResult Update()
        {
            return View();
        }

    }
}