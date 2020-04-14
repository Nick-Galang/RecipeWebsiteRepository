using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Models
{
    public class IngredientList//:IEnumerable
    {
         private Dictionary<string, string> ingredientList = new Dictionary<string, string>();

        

        public void addIngredient(string ingredientName,string qty)
        {
            try
            {
                ingredientList.Add(ingredientName, qty);
            }
            catch(Exception e)
            {
                Console.WriteLine("You already have same the ingredient");
            }
            
        }
        //public IEnumerator GetEnumerator()
        //{
        //    return (IEnumerator)this;
        //}
        public IDictionary<string,string> getList()
        {
            return ingredientList;
        }

    }
}
