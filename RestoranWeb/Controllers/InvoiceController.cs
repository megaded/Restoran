using Restoran.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}