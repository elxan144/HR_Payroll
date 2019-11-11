using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Models;
using HR_Payroll_App.Models.ClassModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Payroll_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly Payroll_DbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(Payroll_DbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
             var result = await signInManager.PasswordSignInAsync(loginModel.Username,loginModel.Password,false,false);

                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Employee");
                }


                ModelState.AddModelError("", "Invalid login ");
            }
            return View();
        }
        
        [Authorize(Roles ="Admin")]
        public IActionResult Register()
        {
            var employes = context.Employees.Select(x =>
              new SelectListItem
              {
                  Text = x.Name + " " + x.Surname + " " + x.FatherName + "(" + x.WorkPlaces.Where(z => z.EmployeeId == x.Id).Select(t => t.Branch.Name).FirstOrDefault() + ")"
              ,
                  Value = x.Id.ToString()
              }).ToList();

            ViewBag.Roles = roleManager.Roles.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            RegisterModel model = new RegisterModel
            {
                Employees = employes
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {

            if (ModelState.IsValid)
            {
                var appUser = new AppUser
                {
                    UserName = registerModel.UserName,
                    Email = registerModel.Email,
                    EmployeeId = registerModel.EmployeeId
                };

                var result = await userManager.CreateAsync(appUser, registerModel.Password);

                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(registerModel.Role);

                    await userManager.AddToRoleAsync(appUser, role.Name);

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                return View(registerModel);
            }

            //var employes = context.Employees.Select(x =>
            //  new SelectListItem
            //  {
            //      Text = x.Name + " " + x.Surname + " " + x.FatherName + "(" + x.WorkPlaces.Where(z => z.EmployeeId == x.Id).Select(t => t.Branch.Name).FirstOrDefault() + ")"
            //  ,
            //      Value = x.Id.ToString()
            //  }).ToList();

            //ViewBag.Roles = roleManager.Roles.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            //registerModel.Employees = employes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}