using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Urb.Domain.Urb.Models;
using Urb.Plan.v2.Views;

namespace Urb.Plan.v2.Services
{
    public class UserService
    {
        public UserManager<IdentityUser> userManager;
        public async Task<IActionResult> SignUp(UserRegisterView userRegisterView)
        {
            Random random = new Random();
            User user = new User
            {
                Email = userRegisterView.Email,
                NormalizedUserName = userRegisterView.UserName

            };
            await 
            userManager.CreateAsync(user, userRegisterView.Password);
            
            
            return Ok(user);
        }

        private IActionResult Ok(User user)
        {
            throw new NotImplementedException();
        }
    }
}
