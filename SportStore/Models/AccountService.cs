
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace SportStore.Components
{
    public class AccountService
    {
        public static async void EnsurePopulated(IApplicationBuilder app,string Email, string Password)
        {
           UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(Email);

            if (user == null)
            {
                user = new IdentityUser(Email);
                await userManager.CreateAsync(user,Password);
            }


        }
        
        
    }
}
