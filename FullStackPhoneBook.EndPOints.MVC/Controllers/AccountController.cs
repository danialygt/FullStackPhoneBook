using FullStackPhoneBook.EndPoints.MVC.Models.AAA;
using FullStackPhoneBook.EndPoints.MVC.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FullStackPhoneBook.EndPoints.MVC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;

        }


        public ViewResult LogIn(string returnUrl)
        {
            return View(new MyLoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(MyLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user =
                await userManager.FindByNameAsync(loginModel.Name);
                if (user == null)
                {
                    user = await userManager.FindByEmailAsync(loginModel.Name);
                }
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Ridi");
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

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
