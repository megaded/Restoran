using Restoran.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranWeb.Controllers
{
    public class TransferController : Controller
    {
        private readonly UnitOfWork unitofWork;

        public TransferController(UnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}