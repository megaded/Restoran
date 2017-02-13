using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran;
using Restoran.Repositories;
using RestoranWeb.Models.LocationViewModel;
using RestoranWeb.Models.CalculationCardViewModel;
using static RestoranWeb.Models.CalculationCardViewModel.CalculationCardViewModel;
using RestoranWeb.Models;

namespace RestoranWeb.Controllers
{
    public class LocationController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public LocationController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Create()
        {
            LocationViewModel model = new LocationViewModel();
            model.Markets = new SelectList(unitOfWork.MarketRep.GetAll(), "MarketId", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Location();
                entity.Name = model.Name;
                entity.MarketId = model.MarketId;
                unitOfWork.LocationRep.Add(entity);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var entity = unitOfWork.LocationRep.Get(id);
            var model = new LocationViewModel();
            model.LocationId = entity.ID;
            model.Name = entity.Name;
            model.MarketId = entity.MarketId;
            return View(model);
        }


        [HttpGet]
        public ActionResult Index()
        {
            var model = unitOfWork.LocationRep.GetAll().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = unitOfWork.LocationRep.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Menu(int? id)
        {
            HttpCookie cookie = new HttpCookie("Restoran");
            Location model = unitOfWork.LocationRep.Get((int)id);
            cookie["locationId"] = id.ToString();
            cookie["marketId"] = model.MarketId.ToString();
            Response.Cookies.Add(cookie);
            return View("Details", model);
        }

        [ActionName("Recipes")]
        [HttpGet]
        public ActionResult CalculationCard()
        {
            var cookies = Request.Cookies["Restoran"];
            var locationId = int.Parse(cookies["locationId"]);
            if (locationId == 0)
            {
                return RedirectToAction("List");
            }
            var location = unitOfWork.LocationRep.Get(locationId);
            var recipes = location.Recipes;
            var products = location.Products;
            List<CalculationCardViewModel> model = new List<CalculationCardViewModel>();
            foreach (var recipe in recipes)
            {
                var card = new CalculationCardViewModel();
                var cardProduct = new ProductCard();
                card.RecipeName = recipe.Name;
                foreach (var product in recipe.Products)
                {
                    var productStorage = products.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
                    if (productStorage == null)
                    {
                        cardProduct.ProductName = product.Product.Name;
                        cardProduct.Price = 0;
                        cardProduct.Value = (double)product.Value;
                    }
                    else
                    {
                        cardProduct.ProductName = productStorage.Product.Name;
                        cardProduct.Price = productStorage.Price;
                        cardProduct.Value = (double)product.Value;
                    }
                    card.ProductsCard.Add(cardProduct);
                }
                model.Add(card);
            }
            return View("CalculationCard", model);
        }

        [HttpGet]
        public ActionResult ProductsDetail()
        {
            var cookies = Request.Cookies["Restoran"];
            var locationId = int.Parse(cookies["locationId"]);
            var location = unitOfWork.LocationRep.Get(locationId);
            var model = location.Products.Select(x=>new ProductViewModel { Name=x.Product.Name,Id=x.ProductId}).ToList();            
            return View("ProductsDetail", model);
        }

        [HttpGet]
        public ActionResult ProductOperation(int id)
        {
            RestoranContext context = new RestoranContext();
            var model = context.Operation.Where(o => o.ProductId == id).ToList();
            return View("ProductOperation", model);
        }
    }
}