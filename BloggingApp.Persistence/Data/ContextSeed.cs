using BloggingApp.Domain.Auth;
using BloggingApp.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloggingApp.Persistence.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        }
    }
}
