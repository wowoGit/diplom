using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.ViewModels;

namespace testing.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
           private readonly UserManager<IdentityUser> userManager;
        public LoginController(
            [FromServices] SignInManager<IdentityUser> _signInManager,
            [FromServices] UserManager<IdentityUser> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }
            
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM input,
            [FromServices] SignInManager<IdentityUser> signInManager,
            [FromServices] UserManager<IdentityUser> userManager)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(input.Email,
                                                               input.Password,
                                                               input.RememberMe,
                                                               lockoutOnFailure: false);
                if(result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(input.Email);
                    var userRoles = await userManager.GetRolesAsync(user);
                    if(userRoles.Count > 0)
                    {
                        var userRole = userRoles.First();
                        switch (userRole)
                        {
                            case "Patient":
                                return RedirectToAction("Index", "Medcard", new { area = "Patient" });
                            case "Admin":
                                return RedirectToAction("Index", "Doctor", new { area = "Admin" });
                            case "Manager":
                                return RedirectToAction("Index", "Patient", new { area = "Manager" });
                            case "Doctor":
                                if(userRoles.Contains("HeadDoctor"))
                                {
                                return RedirectToAction("Index", "Schedule", new { area = "Doctor" });
                                }
                                return RedirectToAction("Details", "Schedule", new { area = "Doctor",UserId = user.Id });
                        }
                    }
                }
            }
            
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
