using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranWeb.Controllers
{
    public class SettingsMenuController : Controller
    {      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult BidsSheets()
        {
            return View();
        }
    }
}