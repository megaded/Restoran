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
    public class ProductController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public ProductController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }  

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Product> products = unitOfWork.ProductRep.GetAll();
            return View(products);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            var units = unitOfWork.UnitRep.GetAll();           
            model.Units = new SelectList(unitOfWork.UnitRep.GetAll(), "UnitId", "Symbol");
            model.ProductСategories = new SelectList(unitOfWork.ProductCategoryRep.GetAll(), "ProductCategoryId", "Name");
            return View("Create", model);
        }
        [HttpPost]
        public ActionResult Create(Product product, int UnitId,int ProductCategoryId)
        {
            product.Unit = unitOfWork.UnitRep.Get(UnitId);
            product.ProductCategory = unitOfWork.ProductCategoryRep.Get(ProductCategoryId);
            unitOfWork.ProductRep.Add(product);
            unitOfWork.Save();            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductViewModel model = new ProductViewModel();
            model.Product =unitOfWork.ProductRep.Get(id);
            model.Units = new SelectList(unitOfWork.UnitRep.GetAll(), "UnitId", "Symbol","Кг");
            model.ProductСategories = new SelectList(unitOfWork.ProductCategoryRep.GetAll(), "ProductCategoryId", "Name");
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult Edit(Product product)
        {
            unitOfWork.ProductRep.Update(product);
            unitOfWork.Save();
            return  RedirectToAction("Index");
        }       
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = unitOfWork.ProductRep.Get(id);
            return View(model);
        } 
    }
}