using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repositories;
using RestoranWeb.Models.BidSheetViewModel;
using Restoran;

namespace RestoranWeb.Controllers
{
    public class BidSheetController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public BidSheetController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var entitys = unitOfWork.MarketRep.GetAll().ToList();
            var model = new BidSheetViewModel();
            SelectList markets = new SelectList(entitys, "MarketId", "Name");
            model.Markets = markets;
            return View(model);
        }
        public ActionResult Select(int? MarkerId)
        {
            HttpCookie cookie = new HttpCookie("Restoran");
            cookie["markerId"] = MarkerId.ToString();
            Response.Cookies.Add(cookie);
            if (MarkerId == null)
                return RedirectToAction("Index");
            var entity = unitOfWork.MarketRep.Get((int)MarkerId);
            if (entity == null)
                return RedirectToAction("Index");
            var model = new BidSheetEditViewModel();
            model.MarketId = (int)MarkerId;
            model.Suppliers = new SelectList(entity.Suppliers, "SupplierId", "Name");            
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult SelectSupplier(int SupplierId)
        {
            var cookie = Request.Cookies["Restoran"];
            cookie["supplierId"] = SupplierId.ToString();
            var marketID = int.Parse(cookie["markerId"]);
            Response.Cookies.Add(cookie);
            var supplier = unitOfWork.SupplierRep.Get(SupplierId);
            var allProducts = unitOfWork.ProductRep.GetAll().ToList();
            var model = new BidSheetProductEditViewModel();
            model.SupplierProducts = supplier.Products.Select(p => new ProductViewModel
            { Name = p.Product.Name, Id = p.ProductId, Unit = p.Product.Unit.Symbol, Price = p.Price }).ToList();
            model.Products = allProducts.Where(p => !supplier.Products.Any(p1 => p1.ProductId == p.ProductId))
                .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.Name ,Unit=p.Unit.Symbol,Price=0m}).ToList();
            TempData["model"] = model;
            return PartialView("Products",model);
        }

        public ActionResult AddProduct(int id)
        {
            var model =(BidSheetProductEditViewModel) TempData["model"];
            var product = model.Products.Where(p => p.Id == id).FirstOrDefault();
            model.SupplierProducts.Add(product);
            model.Products.Remove(product);       
            return PartialView("Products");
        }
    }
}