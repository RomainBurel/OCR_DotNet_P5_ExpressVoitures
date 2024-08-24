using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OCR_DotNet_P5_ExpressVoitures.Data
{
    public static class SeedIdentityData
    {
        private const string ADMIN_ROLE = "Admin";
        private const string ADMIN_ROLE_ID = "e7e1de1a-c073-4b65-888f-57cf2e4590f1";
        private const string ADMIN_USER_EMAIL = "admin@ev.fr";
        private const string ADMIN_USER_ID = "e7e1de1a-c073-4b65-888f-57cf2e4590f2";
        private const string ADMIN_USER_PWD = "P@ssword123";

        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var roleExist = await roleManager.RoleExistsAsync(ADMIN_ROLE);
            if (!roleExist)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = ADMIN_ROLE,
                    NormalizedName = ADMIN_ROLE.ToUpper(),
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID
                };
                IdentityResult identityResult = await roleManager.CreateAsync(identityRole);
            }

            IdentityUser user = await userManager.FindByIdAsync(ADMIN_USER_ID);
            if (user == null)
            {
                user = new IdentityUser
                {
                    Id = ADMIN_USER_ID,
                    Email = ADMIN_USER_EMAIL,
                    NormalizedEmail = ADMIN_USER_EMAIL.ToUpper(),
                    UserName = ADMIN_USER_EMAIL,
                    NormalizedUserName = ADMIN_USER_EMAIL.ToUpper(),
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                await userManager.CreateAsync(user, ADMIN_USER_PWD);
            }

            await userManager.AddToRoleAsync(user, ADMIN_ROLE);
        }
    }
}
