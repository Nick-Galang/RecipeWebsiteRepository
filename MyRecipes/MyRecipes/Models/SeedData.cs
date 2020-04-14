using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MyRecipes.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
    
            if(!context.Recipes.Any())
            {

                context.Recipes.AddRange(

                    new Recipe
                    {

                        RecipeTitle = "Chipotle Chicken Burrito Bowl",
                        Category = "Mexican Cuisine",
                        Description = "Chipotle is the traditional authentic Mexicon food",
                        PrepareTime = "15min",
                        CookTime = "30min",
                        Direction = "1. Heat the vegetable oil in a medium pot over medium-high heat. Add 1/2 cup pico de gallo, the chopped chipotle, and adobo sauce to taste; cook until the mixture starts to sizzle, about 2 minutes. Add the beans and 3/4 cup water; bring to a low boil, then stir in the chicken and cook until the mixture is slightly thickened, about 2 minutes. Stir in the cilantro and season with salt. 2. Heat the tortillas as the label directs. Arrange the rice horizontally in the lower half of each tortilla, leaving a 1 1/2-inch border on all sides. Top evenly with the cheese, chicken mixture, lettuce and the remaining pico de gallo. 3. Fold the bottom edge of each tortilla snugly over the filling, tuck in the sides and roll up tightly. Cut the burritos in half and serve with guacamole.",
                        Photo = "chipotle.png",
                        RecipeIngredients = new List<RecipeIngredient>
                        {
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Vegetable Oil"},
                                Qty="1 Tbsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="Pico de galo" },
                                Qty="¾ cup"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="chipotle chile in adobo sauce" },
                                Qty="1 with 1-2 Tbsp sauce"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="pinto beans" },
                                Qty="1 (14-oz) can"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="rotisserie chicken" },
                                Qty="1 ½ cups shredded"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="cilantro" },
                                Qty="¼ cup ruffly chopped"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="Kosher salt" },
                                Qty=""
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="tortillas" },
                                Qty="4"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="White rice" },
                                Qty="1 ⅓ cups cooked"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{IngredientName="Guacamole" },
                                Qty="1 ⅓ cups shredded"
                            }
                        }
                    },
                    new Recipe
                    {

                        RecipeTitle = "Butter Chicken",
                        Category = "Non Vegetarian",
                        Description = "This easy Indian butter chicken recipe makes Indian food a synch! This creamy tomato sauce is similar to chicken tikka masala, but maybe even better!",
                        PrepareTime = "15min",
                        CookTime = "1hour",
                        Direction = "Using 2 Tbsp of butter in a large skillet over medium-high heat, brown the pieces of the chicken so each side is browned. They do not need to be fully cooked all the way through. Work in batches, and set aside when you’re done.\nMelt another 2 Tbsp of butter in the pan over medium heat. Add the onion, and cook until beginning to soften — about three minutes. Add the garlic, garam masala, ginger, chili powder, cumin, and cayenne. Stir to combine, and cook for about 45 seconds before adding the tomato sauce.\nBring the mixture to a simmer and let cook for five minutes before adding the cream. Bring the mixture back to a simmer, add the browned chicken, and let simmer for 10-15 minutes. Keep the heat low here — not a rolling boil.\nStir in the remaining 2 Tbsp of butter, and season with salt and pepper, to taste.\nServe garnished with lime and cilantro, alongside rice and naan.",
                        Photo = "butter_chicken.jpg",
                        RecipeIngredients = new List<RecipeIngredient>
                        {
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Butter"},
                                Qty="6 Tbsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Chicken breasts"},
                                Qty="2 lbs"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="onion"},
                                Qty="1"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="garlic cloves"},
                                Qty="3"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="garam masala"},
                                Qty="1 Tbsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Ginger"},
                                Qty="1 Tbsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Chili Powder"},
                                Qty="1 Tsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Ground Cumin"},
                                Qty="1 Tsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Cayenne Pepper"},
                                Qty="1/2 tsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Tomato Sauce"},
                                Qty="1 1/2 Tsp"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Cream"},
                                Qty="2 Cups"
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Salt"},
                                Qty=""
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Pepper"},
                                Qty=""
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Lime"},
                                Qty=""
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Naan"},
                                Qty=""
                            },
                            new RecipeIngredient
                            {
                                Ingredient=new Ingredient{ IngredientName="Cooked Rice"},
                                Qty=""
                            }

                        }
                    }
                ) ;
                

                context.SaveChanges();
            }
        }
    }
}
