using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRecipes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MyRecipes.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static IRecipeRepository repository;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(IRecipeRepository rep, UserManager<IdentityUser> user)
        {
            repository = rep;
            userManager = user;
        }
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Authorize(Roles = "General")]
        public ViewResult UserFavorite()
        {
            string user = userManager.GetUserId(HttpContext.User);
            ViewBag.userid = userManager.GetUserId(HttpContext.User);
            return View("UserFavorite", repository.FavoriteRecipes());
        }

        [HttpGet]
        [Authorize(Roles = "General")]
        public ViewResult FavouriteRecipe(Int32 recipeid)
        {
            string user = userManager.GetUserId(HttpContext.User);
            Console.WriteLine("HELLO" + user);

            repository.AddFavorite(recipeid, userManager.GetUserId(HttpContext.User));
            return View("RecipeList", repository.Recipes());
        }

        [AllowAnonymous]
        public ViewResult RecipeList(string searchBy, string search)
        {
            if (searchBy == "Category")
            {
                return View("RecipeList", repository.Recipes().Where(r => r.Category.StartsWith(search) ||
                search == null));
            }
            else
            {
                return View("RecipeList", repository.Recipes().Where(r => r.RecipeTitle.StartsWith(search) ||
                search == null));
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult ViewRecipe(Int32 id)
        {
            Recipe rec = repository.Recipes().Where(r => r.RecipeID == id).FirstOrDefault();

            return View("ViewRecipe", rec);

        }

        public ViewResult ErrorPage()
        {
            ViewBag.errorMsg = "Sorry...";
            return View("ErrorPage");
        }
        [HttpGet]
        [Authorize(Roles = "General")]
        public ViewResult ReviewRecipe(Int32 id)
        {

            Review review = new Review();
            review.RecipeId = id;
            review.Recipe = repository.Recipes().Where(r => r.RecipeID == review.RecipeId).FirstOrDefault();
            return View("ReviewRecipe", review);
        }
        [HttpPost]
        [Authorize(Roles = "General")]
        public ViewResult ReviewRecipe(Review review, Int32 id, string user)
        {
            Recipe rec = repository.Recipes().Where(r => r.RecipeID == id).FirstOrDefault();
            review.RecipeId = rec.RecipeID;
            review.User = user;
            repository.AddReview(review);
            return View("ViewRecipe", rec);
        }

        [Authorize(Roles = "General")]
        public IActionResult OnGetPartial() =>
            new PartialViewResult
            {
                ViewName = "_AddRecipe",
                ViewData = ViewData
            };




    }
}