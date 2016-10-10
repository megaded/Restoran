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
            var model = (RecipeEditViewModel)Session["editRecipe"];
            model.AddProduct(id);
            Session["editRecipe"] = model;
            return PartialView("Edit",model);
        }

        [AjaxOnly]
        public ActionResult RemoveProduct(int id)
        {
            var model = (RecipeEditViewModel)Session["editRecipe"];
            model.RemoveProduct(id);
            Session["editRecipe"] = model;
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
            List<ProductRecipe> products = model.Products.Where(p => p.Value != 0).ToList();
            unitOfWork.CreateRecipe(newRecipe,products);
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
            var target = unitOfWork.RecipeRep.Get(id);
            var model = new RecipeEditViewModel(unitOfWork, target);
            Session["editRecipe"] = model;
            return View("MainEdit",model);
        }
        [HttpPost]
        public ActionResult Edit(RecipeEditViewModel model)
        {
            var recipe = model.EditRecipe;
            recipe.Products = model.Products;
            unitOfWork.RecipeRep.Update(recipe);
            unitOfWork.Save();
            Session.Clear();
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