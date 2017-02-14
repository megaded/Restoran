using Restoran.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoranWeb.Models.InvoiceViewModel;

namespace RestoranWeb.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly UnitOfWork unitofWork;

        public InvoiceController(UnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public ActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Accept(int id)
        {
            var order = unitofWork.OrderRep.Get(id);
            InvoiceViewModel model = new InvoiceViewModel();
            model.SupplierId = order.Supplier.SupplierId;
            model.SupplierName = order.Supplier.Name;
            model.Products = order.Products.Select(p => new ProductInvoiceViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.Product.Name,
                Unit = p.Product.Unit.Symbol,
                Price = p.Price,
                OrderValue = p.Value,
                InvoiceValue = p.Value,
                Tax = 18
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Accept(InvoiceViewModel model)
        {
            int c
            return View();
        }
    }
}