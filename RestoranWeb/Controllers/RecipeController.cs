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
        [AjaxOnly]
        public ActionResult AddProduct(int id)
        {
            var model = (RecipeEditViewModel)TempData["editRecipe"];
            model.AddProduct(id);
            TempData["editRecipe"] = model;
            return PartialView("Edit",model);
        }

        [AjaxOnly]
        public ActionResult RemoveProduct(int id)
        {
            var model = (RecipeEditViewModel)TempData["editRecipe"];
            model.RemoveProduct(id);
            TempData["editRecipe"] = model;
            return PartialView("Edit", model);
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
            return View("MainEdit",model);
        }
        [HttpPost]
        public ActionResult Edit(Recipe recipe,List<ProductRecipe> products)
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
    }
}