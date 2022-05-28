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
    [Authorize]
    public class LoginController : Controller
    {
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM input,
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
                    var user = await userManager.FindByEmailAsync(input.Email);
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
                                return RedirectToAction("Index", "Schedule", new { area = "Doctor" });
                        }
                    }
                }
            }
            
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
