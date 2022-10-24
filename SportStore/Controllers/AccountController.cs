using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportStore.Controllers;
using SportStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;
        

        public AccountController(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr,IMapper mapper)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            this.mapper = mapper;
           
        }
        [AllowAnonymous]
        public ViewResult Login(string returnUrl="admin/login")
        {
            return View();
            
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            IdentityUser user = await userManager.FindByEmailAsync(loginModel.Email);

            if (user != null)
            {
               await signInManager.CanSignInAsync(user);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user.Email,
                    loginModel.Password,false,false)).Succeeded)
                    {
                        return RedirectToAction(nameof(AdminController.Index), "Admin");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Registry()
        {
           
            return View();
        }

        public async Task<IActionResult> Registry(LoginModel loginModel)
        {

           // loginModel.ReturnUrl = "/admin/index";
            if (ModelState.IsValid)
            {
                var user = mapper.Map<IdentityUser>(loginModel);

                var result = await userManager.CreateAsync(user, loginModel.Password);
                return Redirect("login");

            }
            return View(loginModel);



        }
    }
}


