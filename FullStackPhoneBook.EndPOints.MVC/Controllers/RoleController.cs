using FullStackPhoneBook.EndPoints.MVC.Models.AAA;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FullStackPhoneBook.EndPoints.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<MyIdentityRole> roleManager;

        public RoleController(RoleManager<MyIdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public IActionResult Index()
        {
            AddRoleModel roleModel = new AddRoleModel
            {
                rolesForDisplay = roleManager.Roles.ToList()
            };
            if (roleModel.rolesForDisplay.Count == 0)
            {
                ModelState.AddModelError("NotExictsRole", "there is no roles. please add role!");
            }

            return View(roleModel);
        }



        [HttpPost]
        public IActionResult Create(MyIdentityRole identityRole)
        {
            MyIdentityRole role = new MyIdentityRole
            {
                Name = identityRole.Name
            };

            var result = roleManager.CreateAsync(role).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var role = roleManager.FindByIdAsync(id.ToString()).Result;
            MyIdentityRole model = new MyIdentityRole();
            if (role != null)
            {
                model.Name = role.Name;
            }
            else
            {
                ModelState.AddModelError("NotExictsRole", "This roles not found!");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, MyIdentityRole identityRole)
        {
            var role = roleManager.FindByIdAsync(id.ToString()).Result;
            if (role != null)
            {
                role.Name = identityRole.Name;
                var result = roleManager.UpdateAsync(role).Result;
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
                ModelState.AddModelError("NotExictsRole", "This roles not found!");
            }

            return View(identityRole);
        }

        public IActionResult Delete(int id)
        {
            var role = roleManager.FindByIdAsync(id.ToString()).Result;
            if (role != null)
            {
                var result = roleManager.DeleteAsync(role).Result;
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("NotExictsRole", "This roles not found!");
            }
            return RedirectToAction("Index");
        }









    }
}