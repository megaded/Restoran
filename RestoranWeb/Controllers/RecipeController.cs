using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran;
using RestoranWeb.Models;
using Restoran.Repositories;
using System.Web.Mvc.Ajax;
using RestoranWeb.Infrastructure;

namespace RestoranWeb.Controllers
{
    public class RecipeController : Controller
    {
        private UnitOfWork unitOfWork;

        public RecipeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var recipe = unitOfWork.RecipeRep.GetAll();
            return View(recipe);
        }

        [HttpGet]
        public ActionResult Create()
        {
            RecipeCreateViewModel model = new RecipeCreateViewModel(unitOfWork);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(RecipeCreateViewModel model)
        {
            Recipe newRecipe = new Recipe();
            newRecipe.Name = model.Name;
            newRecipe.Description = model.Description;
            newRecipe.Products = model.Products;
            unitOfWork.RecipeRep.Add(newRecipe);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = unitOfWork.RecipeRep.Get(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new RecipeEditViewModel(unitOfWork, id);
            TempData["editRecipe"] = model;
            return View("MainEdit", model);
        }
        [HttpPost]
        public ActionResult Edit(Recipe recipe, List<ProductRecipe> products)
        {
            recipe.Products = products;
            unitOfWork.RecipeRep.Update(recipe);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var target = unitOfWork.RecipeRep.Get(id);
            if (target != null)
            {
                unitOfWork.RecipeRep.Remove(target);
                unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }
        [AjaxOnly]
        public ActionResult AddProduct(int id)
        {
            var model = (RecipeEditViewModel)TempData["editRecipe"];
            model.AddProduct(id);
            TempData["editRecipe"] = model;
            return PartialView("Edit", model);
        }

        [AjaxOnly]
        public ActionResult RemoveProduct(int id)
        {
            var model = (RecipeEditViewModel)TempData["editRecipe"];
            model.RemoveProduct(id);
            TempData["editRecipe"] = model;
            return PartialView("Edit", model);
        }

        [ActionName("Locations")]
        [HttpGet]
        public ActionResult RecipeLocations(int id)
        {
            var location = unitOfWork.LocationRep.GetAll().ToList();
            RecipeLocationViewModel model = new RecipeLocationViewModel();
            model.Id = id;
            model.RecipeLocation = location.Where(r => r.Recipes.Any(re => re.RecipeId == model.Id)).ToList();
            if (model.RecipeLocation == null)
            {
                model.NoRecipeLocation = location;
            }
            else
            {
                model.NoRecipeLocation =location.Where(p => !model.RecipeLocation.Any(r =>p.ID==r.ID)).ToList();
            }

            TempData["locationRecipe"] = model;
            return View("Locations", model);
        }
        [AjaxOnly]
        public ActionResult AddLocation(int locId)
        {
            RecipeLocationViewModel model = (RecipeLocationViewModel)TempData["locationRecipe"];
            var location = model.NoRecipeLocation.Where(p => p.ID == locId).FirstOrDefault();
            if (location != null)
            {
                model.RecipeLocation.Add(location);
                model.NoRecipeLocation.Remove(location);
            }
            TempData["locationRecipe"] = model;
            return PartialView("LocationsEdit", model);
        }
        [AjaxOnly]
        public ActionResult RemoveLocation(int locId)
        {
            RecipeLocationViewModel model = (RecipeLocationViewModel)TempData["locationRecipe"];
            var location = model.RecipeLocation.Where(p => p.ID == locId).FirstOrDefault();
            if (location != null)
            {
                model.NoRecipeLocation.Add(location);
                model.RecipeLocation.Remove(location);
            }
            TempData["locationRecipe"] = model;
            return PartialView("LocationsEdit", model);
        }

        [HttpPost]
        public ActionResult EditLocation(RecipeLocationViewModel model)
        {
            var editModel = unitOfWork.RecipeRep.Get(model.Id);
            var editModelLocation = editModel.Locations.ToList();
            foreach (var location in editModelLocation)
            {
                editModel.Locations.Remove(location);
            }
            foreach (var location in model.RecipeLocation)
            {
                var loc = unitOfWork.LocationRep.Get(location.ID);
                editModel.Locations.Add(loc);
            }

            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}