using Microsoft.AspNetCore.Identity;
using WebProjesi.Models;

namespace WebProjesi.Data
{
    public static class Rol
    {
        public static async Task InitializeAsync(UserManager<Kullanici> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Define roles
            var roles = new[] { "Admin", "Calisan", "Kullanici" };

            // Create roles if they do not exist
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create Admin user
            var adminEmail = "muhammed.elzabi@ogr.sakarya.edu.tr";
            var adminPassword = "sau";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new Kullanici
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Ad = "Elzabi"
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }           
        }
    }
}
