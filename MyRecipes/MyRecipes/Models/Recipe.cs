using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; } 
        public string RecipeTitle { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string PrepareTime { get; set; }
        public string CookTime { get; set; }
        public string Direction { get; set; }
        public string Photo { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime date { get; set; }
        public IEnumerable<UserFavourite> UserFavourites { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }


    }
}
