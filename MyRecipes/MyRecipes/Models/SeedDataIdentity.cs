using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MyRecipes.Models
{
    public static class SeedDataIdentity
    {
        private const string userName = "Shirin";
        private const string pass = "Pass&229";
        private const string userName2 = "Romnick";
        private const string pass2 = "Comp&229";


        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationIdentityDbContext db = app.ApplicationServices
               .GetRequiredService<ApplicationIdentityDbContext>();
            db.Database.Migrate();
            
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();
            var r = await roleManager.RoleExistsAsync("General");
            if(!r)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "General";
                await roleManager.CreateAsync(role);
            }

            //initialization of first user
            IdentityUser user = new IdentityUser();
            user.UserName = userName;
            IdentityResult result = await userManager.CreateAsync(user, pass);
            if(result.Succeeded)
            {
                 await userManager.AddToRoleAsync(user, "General");
            }

            //initialization of second user
            user = new IdentityUser();
            user.UserName = userName2;
             result = await userManager.CreateAsync(user, pass2);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "General");
            }

        }
    }
}
