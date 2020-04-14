using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyRecipes.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes()
        {
            return context.Recipes.Include(f => f.UserFavourites).Include(rec => rec.Reviews).Include(rec => rec.RecipeIngredients).ThenInclude(i => i.Ingredient);
        }
        //public void AddIngredient(string name,string qty)
        //{


        //    Ingredient i = context.Ingredients.Where(n => n.IngredientName == name).FirstOrDefault();
        //    if(i==null)
        //    {
        //        Ingredient ing = new Ingredient { IngredientName = name };
        //        context.Ingredients.Add(ing);
        //        RecipeIngredient r = new RecipeIngredient { Ingredient = ing,Qty=qty };
        //    }
        //    else
        //    {
        //        RecipeIngredient r = new RecipeIngredient { Ingredient = i ,Qty=qty};
        //    }

        //    context.SaveChanges();
        //}
        public void AddRecipe(Recipe recipe, IngredientList ingredients)
        {

            List<RecipeIngredient> r = new List<RecipeIngredient>();
            foreach (KeyValuePair<string, string> ingredient in ingredients.getList())
            {
                Ingredient ing = context.Ingredients.Where(i => i.IngredientName == ingredient.Key).FirstOrDefault();
                if (ing != null)
                {
                    r.Add(new RecipeIngredient { Ingredient = ing, Qty = ingredient.Value });
                }
                else
                {
                    r.Add(new RecipeIngredient { Ingredient = new Ingredient { IngredientName = ingredient.Key }, Qty = ingredient.Value });
                }

            }
            recipe.RecipeIngredients = r;

            context.Recipes.Add(recipe);
            context.SaveChanges();
        }
        public void UpdateRecipe(Recipe rec, int id, IngredientList ingredients)
        {
            Recipe recipe = context.Recipes.Where(re => re.RecipeID == id).FirstOrDefault();
            List<RecipeIngredient> r = new List<RecipeIngredient>();
            r.AddRange(recipe.RecipeIngredients);
            foreach (KeyValuePair<string, string> ingredient in ingredients.getList())
            {
                Ingredient ing = context.Ingredients.Where(i => i.IngredientName == ingredient.Key).FirstOrDefault();
                if (ing != null)
                {
                    r.Add(new RecipeIngredient { Ingredient = ing, Qty = ingredient.Value });
                }
                else
                {
                    r.Add(new RecipeIngredient { Ingredient = new Ingredient { IngredientName = ingredient.Key }, Qty = ingredient.Value });
                }

            }

            recipe.PrepareTime = rec.PrepareTime;
            recipe.CookTime = rec.CookTime;
            recipe.Description = rec.Description;
            recipe.Direction = rec.Direction;
            recipe.UserName = rec.UserName;
            recipe.date = DateTime.Now;

            recipe.RecipeIngredients = r;
            context.SaveChanges();

        }
        public void DeleteIngredient(int recipeid, int ingredientid)
        {
            RecipeIngredient r = new RecipeIngredient { RecipeId = recipeid, IngredientId = ingredientid };
            context.RecipeIngredient.Remove(r);
            context.SaveChanges();
        }
        public void DeleteRecipe(int id)
        {
            context.Recipes.Remove(context.Recipes.Where(r => r.RecipeID == id).FirstOrDefault());
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

            try
            {
                UserFavourite userFav = new UserFavourite { UserID = userId, RecipeID = recipeId, Recipe = recipe };
                context.UserFavourites.Add(userFav);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Data already exists");
            }

        }
        public IQueryable<UserFavourite> FavoriteRecipes()
        {
            return context.UserFavourites.Include(r => r.Recipe);
        }


    }
}
