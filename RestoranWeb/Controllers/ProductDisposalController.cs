using Restoran.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoranWeb.Models;
using Restoran;

namespace RestoranWeb.Controllers
{
    public class ProductDisposalController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public ProductDisposalController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var cookie = Request.Cookies["Restoran"];
            var locationId = int.Parse(cookie["locationId"]);
            var model = unitOfWork.ProductDRep.GetAll().Where(m=>m.LocationId==locationId).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var cookie = Request.Cookies["Restoran"];
            var locationId = int.Parse(cookie["locationId"]);
            var location = unitOfWork.LocationRep.Get(locationId);
            if (location == null)
            {
                return RedirectToAction("List");
            }
            var products = location.Products;
            var reason = unitOfWork.ReasonRep.GetAll();
            var model = new DispocalViewModel();
            model.Reason = new SelectList(reason, "ReasonId", "Name");
            model.Products = new List<ProductDisposalViewModel>();
            foreach (var product in products)
            {
                model.Products.Add(new ProductDisposalViewModel
                {
                    ProductName = product.Product.Name,
                    ProductId = product.Product.ProductId,
                    Amount = product.Value,
                    UnitId = product.Product.UnitId,
                    UnitSymbol = product.Product.Unit.Symbol
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(DispocalViewModel model)
        {

            var products = model.Products.Where(m => m.AmountDispocal > 0);
            var cookie = Request.Cookies["Restoran"];
            var locationId = int.Parse(cookie["locationId"]);
            var productDisposal = new ProductDisposal();
            productDisposal.Date = DateTime.Now;
            productDisposal.LocationId = locationId;
            productDisposal.ReasonId = model.ReasonId;
            foreach (var product in products)
            {
                productDisposal.Products.Add(new DisposalProduct
                {
                    ProductId = product.ProductId,
                    Amount = product.AmountDispocal
                });
            }
            unitOfWork.ProductDRep.Add(productDisposal);
            unitOfWork.Save();
            var location = unitOfWork.LocationRep.Get(locationId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}