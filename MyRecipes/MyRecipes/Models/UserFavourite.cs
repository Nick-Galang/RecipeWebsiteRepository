using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace MyRecipes.Models
{
    public class UserFavourite
    {
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
        public string UserID { get; set; }
       
        
    }
}
