using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran;
using Restoran.Repositories;
using RestoranWeb.Models;

namespace RestoranWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public OrderController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]        
        public ActionResult Detail(int id)
        {
            var products = unitOfWork.OrderRep.Get(id).Products;
            return View(products);
        }

        [HttpGet]
        [ActionName("Orders")]
        public ActionResult Index()
        {
            var cookie = Request.Cookies["Restoran"];
            var locationId = int.Parse(cookie["locationId"]);
            if (locationId ==0)
                return RedirectToAction("Index","Location");
            var orders = unitOfWork.OrderRep.GetAll().Where(p => p.LocationId == locationId).ToList();
            OrdersListViewModel model = new OrdersListViewModel(orders);
            return View("Index",model);
        }
        [HttpPost]
        public ActionResult Create(OrderCreateViewModel model)
        {
            HttpCookie cookie = Request.Cookies["Restoran"];
            int locationId = int.Parse(cookie["locationId"]);
            unitOfWork.CreateOrder(model.ProductOrdered, model.Id, locationId);
            return RedirectToAction("Orders");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            unitOfWork.OrderRep.Remove(unitOfWork.OrderRep.Get(id));
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Accept(int id)
        {
            var order = unitOfWork.OrderRep.Get(id);
            if (order != null)
            {
                if (!order.Accept)
                {
                    unitOfWork.AcceptOrder(id);
                    unitOfWork.Save();
                }
                else
                {
                    ViewBag.ErrorMessage = "Заказ уже принят";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Заказ не найден";
                return View("Error");
            }
            return RedirectToAction("Orders");
        }
    }
}