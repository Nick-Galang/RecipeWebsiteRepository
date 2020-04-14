using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MyRecipes.Controllers
{
    public class CRUDController : Controller
    {
        private IRecipeRepository repository;
        private static IngredientList ingredients = new IngredientList();
        private readonly UserManager<IdentityUser> userManager;
        public CRUDController(IRecipeRepository rep,UserManager<IdentityUser> user)
        {
            repository = rep;
            userManager = user;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "General")]
        public IActionResult AddIngredient(string name, string qty)
        {

            ingredients.addIngredient(name, qty);
            return RedirectToAction("AddRecipe", "CRUD");
        }

        [HttpGet]
        [Authorize(Roles = "General")]
        public ViewResult AddRecipe()
        {
            
            return View("AddRecipe");
        }


        [HttpPost]
        [Authorize(Roles = "General")]
        public IActionResult AddRecipe(Recipe recipe,string user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.userId = userManager.GetUserId(HttpContext.User);
                recipe.UserId = ViewBag.userId;
                repository.AddRecipe(recipe,ingredients);
                return RedirectToAction("RecipeList","Home", repository.Recipes());
            }
            else
            {
                return View("AddRecipe");
            }
        }

        [HttpGet]
        [Authorize(Roles = "General")]
        public IActionResult UpdateRecipe(Int32 id)
        {
            Recipe rec = repository.Recipes().Where(r => r.RecipeID == id).FirstOrDefault();
            if (userManager.GetUserId(HttpContext.User) == rec.UserId)
            {
                ingredients = new IngredientList();
                return View("UpdateRecipe", rec);
            }
            else
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        
        [HttpGet]
        public ViewResult DeleteIngredient(Int32 recipeid,Int32 recipeingredientid)
        {
           
            repository.DeleteIngredient(recipeid, recipeingredientid);
            Recipe rec = repository.Recipes().Where(r => r.RecipeID == recipeid).FirstOrDefault();
            return View("UpdateRecipe",rec);
        }


        [HttpPost]
        [Authorize(Roles = "General")]
        public IActionResult UpdateRecipe(Recipe rec,Int32 id,string name)
        {
            Recipe recipe = repository.Recipes().Where(r => r.RecipeID == id).FirstOrDefault();
            if (userManager.GetUserId(HttpContext.User)==recipe.UserId)
            {
                rec.date = DateTime.Now;
                rec.UserName = name;
                repository.UpdateRecipe(rec,id);
                return RedirectToAction("RecipeList","Home", rec);
            }
            else
            {
                
                return RedirectToAction("ErrorPage","Home");
            }
            
        }

        [HttpGet]
        [Authorize(Roles = "General")]
        public IActionResult DeleteRecipe(Int32 id)
        {
            Recipe recipe = repository.Recipes().Where(r => r.RecipeID == id).FirstOrDefault();
            if (userManager.GetUserId(HttpContext.User) == recipe.UserId)
            {
                repository.DeleteRecipe(id);
                return RedirectToAction("RecipeList", "Home");
            }
            else
            {

                return RedirectToAction("ErrorPage", "Home");
            }
        }


    }
}