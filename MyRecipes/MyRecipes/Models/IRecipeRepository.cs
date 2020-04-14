using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes();
        void AddRecipe(Recipe recipe, IngredientList ingredients);

        void DeleteIngredient(int recipeid, int ingredientid);
        void UpdateRecipe(Recipe recipe, int id, IngredientList ingredients);
        void DeleteRecipe(int id);
        void AddReview(Review review);
        void AddFavorite(int recipeId, string userId);
        IQueryable<UserFavourite> FavoriteRecipes();
    }
}
