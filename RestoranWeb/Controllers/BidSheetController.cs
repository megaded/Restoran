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
        [HttpGet]
        public ActionResult Index()
        {
            var entitys = unitOfWork.MarketRep.GetAll().ToList();
            var model = new BidSheetViewModel();
            SelectList markets = new SelectList(entitys, "MarketId", "Name");
            model.Markets = markets;
            return View(model);
        }
        [HttpPost]
        public ActionResult Select(int? MarkerId)
        {
            HttpCookie cookie = new HttpCookie("Restoran");
            cookie["marketId"] = MarkerId.ToString();
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
            var marketID = int.Parse(cookie["marketId"]);
            Response.Cookies.Add(cookie);
            var supplier = unitOfWork.SupplierRep.Get(SupplierId);
            var supplierProduct = supplier.Products.Where(p => p.MarketId == marketID).ToList();
            var allProducts = unitOfWork.ProductRep.GetAll().ToList();
            var model = new BidSheetProductEditViewModel();
            model.SupplierProducts = supplierProduct.Select(p => new ProductViewModel
            { Name = p.Product.Name, Id = p.ProductId, Unit = p.Product.Unit.Symbol, Price = p.Price }).ToList();
            model.Products = allProducts.Where(p => !supplierProduct.Any(p1 => p1.ProductId == p.ProductId))
                .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.Name, Unit = p.Unit.Symbol, Price = 0m }).ToList();
            TempData["model"] = model;
            return PartialView("Products", model);
        }

        public ActionResult AddProduct(int id)
        {
            var model = (BidSheetProductEditViewModel)TempData["model"];
            var product = model.Products.Where(p => p.Id == id).FirstOrDefault();
            model.SupplierProducts.Add(product);
            model.Products.Remove(product);
            TempData["model"] = model;
            return PartialView("Products", model);
        }
        public ActionResult RemoveProduct(int id)
        {
            var model = (BidSheetProductEditViewModel)TempData["model"];
            var product = model.SupplierProducts.Where(p => p.Id == id).FirstOrDefault();
            model.Products.Add(product);
            model.SupplierProducts.Remove(product);
            TempData["model"] = model;
            return PartialView("Products", model);
        }

        [HttpPost]
        public ActionResult Save(List<ProductViewModel> SupplierProducts)
        {
            var cookie = Request.Cookies["Restoran"];
            var supplierId = int.Parse(cookie["supplierId"]);
            var marketId = int.Parse(cookie["marketId"]);
            var products = SupplierProducts.Where(p => p.Price > 0);
            var entities = unitOfWork.ProdSup.GetAll().Where(p => p.SupplierId == supplierId && p.MarketId == marketId);
            foreach (var entity in entities)
            {
                unitOfWork.ProdSup.Remove(entity);
            }
            foreach (var product in products)
            {
                unitOfWork.ProdSup.Add(new ProductSupplier
                {
                    SupplierId=supplierId,
                    MarketId=marketId,
                    ProductId=product.Id,
                    Price=product.Price
                });
            }
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}