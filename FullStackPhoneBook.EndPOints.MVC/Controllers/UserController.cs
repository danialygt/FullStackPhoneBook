using FullStackPhoneBook.EndPoints.MVC.Models.AAA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace FullStackPhoneBook.EndPoints.MVC.Controllers
{
    //[Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<MyIdentityRole> roleManager;


        public UserController(UserManager<AppUser> userManager,
            RoleManager<MyIdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.Take(50).ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday
                };
                var result = userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return View(model);
        }




        public IActionResult Update(int id)
        {
            var user = userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                UpdateUserViewModel model = new UpdateUserViewModel
                {
                    Email = user.Email,
                    FullName = $"{user.FirstName} {user.LastName}"
                };
                return View(model);
            }
            else
            {
                ModelState.AddModelError("NotExistUser", "User Not Found");
                return View(id);
            }
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateUserViewModel updateUserViewModel)
        {
            var user = userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                user.Email = updateUserViewModel.Email;
                var result = userManager.UpdateAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("NotExistUser", "User Not Found");
            }
            return View(updateUserViewModel);
        }



        public IActionResult Delete(int id)
        {
            var model = userManager.FindByIdAsync(id.ToString()).Result;
            if (model == null)
            {
                ModelState.AddModelError("NotExistUser", "User Not Found");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(AppUser deleteUserModel)
        {
            var user = userManager.FindByIdAsync(deleteUserModel.Id.ToString()).Result;
            if (user != null)
            {
                var result = userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("NotExistUser", "User Not Found");
            }
            return View();
        }



        public IActionResult AddToRole(int id)
        {
            var roles = roleManager.Roles.ToList();
            var user = userManager.FindByIdAsync(id.ToString()).Result;
            AddRoleModel addRoleModel = new AddRoleModel();

            if (roles != null)
            {
                if (user != null)
                {
                    var userRoles = userManager.GetRolesAsync(user).Result;

                    addRoleModel.rolesForDisplay = new List<MyIdentityRole>();

                    foreach (var item in roles)
                    {
                        if (!userRoles.Contains(item.Name))
                        {
                            addRoleModel.rolesForDisplay.Add(item);
                        }
                    }

                    addRoleModel.User = user;

                    if (addRoleModel.rolesForDisplay.Count == 0)
                    {
                        ModelState.AddModelError("NotExictsRoles", "user have all roles");
                    }
                }
                else
                {
                    ModelState.AddModelError("NotExictsUser", "user not found. please add user!");
                }
            }
            else
            {
                ModelState.AddModelError("NotExictsRole", "there is no roles. please add role!");
            }

            return View(addRoleModel);
        }

        [HttpPost]
        public IActionResult AddToRole(int id, AddRoleModel addRoleModel)
        {

            var user = userManager.FindByIdAsync(id.ToString()).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;

            if (user != null)
            {
                if (!userRoles.Contains(addRoleModel.selectedRole))
                {
                    var result = userManager.AddToRoleAsync(user, addRoleModel.selectedRole).Result;
                    if (result == IdentityResult.Success)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(item.Code, item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("AlreadyExictsRole", "already user have this role!");
                }
            }
            else
            {
                ModelState.AddModelError("NotExictsUser", "user not found.");
            }
            return View(addRoleModel);
        }


    }
}
