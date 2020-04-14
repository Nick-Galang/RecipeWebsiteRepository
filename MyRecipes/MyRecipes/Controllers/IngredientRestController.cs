using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Models;

namespace MyRecipes.Controllers
{
    [Route("api/ingredient")]
    public class IngredientRestController : ControllerBase
    {
        private ApplicationDbContext db=new ApplicationDbContext();

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = db.Ingredients.Where(p => p.IngredientName.Contains(term)).Select(p => p.IngredientName).ToList();
                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}