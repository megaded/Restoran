﻿using System;
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
        public ActionResult Index()
        {
            OrdersListViewModel model = new OrdersListViewModel();
            int warehouseId = (int)Session["warehouseID"];
            var orders = unitOfWork.OrderRep.GetAll().ToList();
            orders = orders.Where(x => x.LocationId == warehouseId).ToList();
            model.AccertOrders = orders.Where(o => o.Accept==true).ToList();
            model.NotAcceptOrders = orders.Where(o => o.Accept == false).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var suppliers = unitOfWork.SupplierRep.GetAll();
            return View(suppliers);
        }

        [HttpPost]
        public ActionResult Create(OrderCreateViewModel model)
        {
            int supplierId = (int)TempData["supplierId"];
            int warehouseId = (int)Session["warehouseID"];
            unitOfWork.CreateOrder(model.ProductOrdered, supplierId, warehouseId);
            return View("Complete");
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
            return RedirectToAction("Index");
        }
    }
}