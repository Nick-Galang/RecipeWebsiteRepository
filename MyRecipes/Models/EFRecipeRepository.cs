using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyRecipes.Models
{
    public class EFRecipeRepository:IRecipeRepository
    {
        private ApplicationDbContext context;
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes()
        {
            return context.Recipes.Include(f=>f.UserFavourites).Include(rec => rec.Reviews).Include(rec=>rec.RecipeIngredients).ThenInclude(i=>i.Ingredient);
        }
        public void AddIngredient(string name,string qty)
        {
            Ingredient ing = new Ingredient { IngredientName = name };
            RecipeIngredient r = new RecipeIngredient { Ingredient = ing };
            
            context.Ingredients.Add(ing);
            context.SaveChanges();
        }
        public void AddRecipe(Recipe recipe,IngredientList ingredients)
        {

            List<RecipeIngredient> r = new List<RecipeIngredient>();
            foreach (KeyValuePair<string, string> ingredient in ingredients.getList())
            {
                r.Add(new RecipeIngredient { Ingredient = new Ingredient { IngredientName = ingredient.Key }, Qty = ingredient.Value });
            }
            recipe.RecipeIngredients = r;
            
            context.Recipes.Add(recipe);
            context.SaveChanges();
        }
        public void UpdateRecipe(Recipe rec,int id)
        {
            Recipe re = context.Recipes.Where(r =>r.RecipeID==id).FirstOrDefault();  
            re.PrepareTime = rec.PrepareTime;
            re.CookTime = rec.CookTime;
            re.Description = rec.Description;
            re.Direction = rec.Direction;
            re.UserName = rec.UserName;
            context.SaveChanges();

        }
        public void DeleteIngredient(int recipeid, int ingredientid)
        {
            RecipeIngredient r = new RecipeIngredient {RecipeId=recipeid,IngredientId=ingredientid };
            context.RecipeIngredient.Remove(r);
            context.SaveChanges();
        }
        public void DeleteRecipe(int id)
        {
            context.Recipes.Remove(context.Recipes.Where(r=>r.RecipeID==id).FirstOrDefault());
            context.SaveChanges();
        }
        public void AddReview(Review review)
        {
            
            context.Reviews.Add(review);
            context.SaveChanges();
        }

        public void AddFavorite(int recipeId, string userId)
        {
            Recipe recipe = context.Recipes.Where(r => r.RecipeID == recipeId).FirstOrDefault();
            UserFavourite userFav = new UserFavourite { UserID = userId, RecipeID = recipeId, Recipe=recipe};
            context.UserFavourites.Add(userFav);
            context.SaveChanges();
        }
        public IQueryable<UserFavourite> FavoriteRecipes()
        {
            return context.UserFavourites.Include(r=>r.Recipe);
        }


    }
}
