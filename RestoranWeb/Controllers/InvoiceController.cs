using Restoran.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoranWeb.Models.InvoiceViewModel;
using Restoran;

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


        public ActionResult Update(List<ProductInvoiceViewModel> model)
        {            
            return PartialView("Invoice", model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var order = unitofWork.OrderRep.Get(id);
            InvoiceViewModel model = new InvoiceViewModel();
            model.SupplierId = order.Supplier.SupplierId;
            model.LocationId = order.LocationId;
            model.Date = DateTime.Now;
            model.SupplierName = order.Supplier.Name;
            model.Products = order.Products.Select(p => new ProductInvoiceViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.Product.Name,
                Unit = p.Product.Unit.Symbol,
                Price = p.Price,
                OrderValue = p.Value,
                InvoiceValue = p.Value,
                Tax = 1.18,
                PriceWithTax=p.Price*(decimal)1.18
            }).ToList();
            return View("Detail", model);
        }

        [HttpPost]
        public ActionResult Accept(InvoiceViewModel model)
        {
            var entity = new Invoice();
            RestoranContext context = new RestoranContext();
            entity.Date = model.Date;
            entity.InvoiceNumber = model.InvoiceNumber;
            entity.VATInvoice = model.VATInvoice;
            entity.SupplierId = model.SupplierId;
            entity.LocationId = model.LocationId;
            entity.OrderId = model.OrderId;
            foreach (var product in model.Products)
            {
                entity.Products.Add(new ProductInvoice
                {
                    ProductId = product.ProductId,
                    Tax = product.Tax,
                    Price = product.Price,
                    Value=product.InvoiceValue
                });
            }
            unitofWork.LocationRep.Get(model.LocationId).Invoices.Add(entity);
            var order = unitofWork.OrderRep.Get(model.OrderId);
            order.Accept = true;
            order.AcceptDate = DateTime.Now;
            unitofWork.OrderRep.Update(order);
            unitofWork.Save();
            return View();
        }
    }
}