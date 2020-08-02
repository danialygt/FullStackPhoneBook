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

            AppUser user = await userManager.FindByNameAsync(loginModel.Name);
            if (user == null)
            {
                user = await userManager.FindByEmailAsync(loginModel.Name);
            }
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    signInManager.SignOutAsync();

                    var result = signInManager.PasswordSignInAsync(user.UserName, loginModel.Password, false, false).Result;



                    if (result.Succeeded)
                    {
                        if (loginModel.ReturnUrl == null)
                        {
                            return RedirectToAction("", "Home");
                        }
                        else
                        {
                            if (HttpContext.User.Identity.IsAuthenticated) // inja true nmishe :(
                            {
                                return Redirect("Alan vared shode!");
                            }
                            return RedirectToAction("", loginModel.ReturnUrl.Trim('/'));
                        }
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
