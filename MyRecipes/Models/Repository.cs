using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Models
{
    public static class Repository
    {
        //private static int Id { get; set; } = 0;
        private static List<Recipe> recipes = new List<Recipe>();
                   
        public static IEnumerable<Recipe> Recipes
        {
            get
            {               
                return recipes;
            }
        }
        public static void AddRecipe(Recipe recipe)
        {
 
            recipes.Add(recipe);
        }        
    }
}
