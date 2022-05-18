
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    public static class IdentitySeedData {
        private const string adminUser="Admin";
        private const string adminPwd="Secret123$";
        private const string adminEmail="rainknightpox@gmail.com";
        private const string adminIphone="13928245451";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            if(user == null)
            {
                user = new IdentityUser(adminUser);
                user.Email = adminEmail;
                user.PhoneNumber = adminIphone;
                user.AccessFailedCount = 5;
                await userManager.CreateAsync(user,adminPwd);
            }
        }
    }
}