using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;
using testing.Services;

namespace testing.Controllers
{
    public class HomeController : BaseController
    {

        private readonly RoleManager<IdentityRole> manager;
        public HomeController(RoleManager<IdentityRole> roleManager,IConfiguration configuration)
            :base(configuration.GetConnectionString("DefaultConnection"))
        {
            manager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //var user = new IdentityUser { Email = "patient@gmail.com", UserName = "patient@gmail.com" };
            //await _userManager.CreateAsync(user, "123123");
            //await _userManager.AddToRoleAsync(user, "Patient");
            //await manager.CreateAsync(new IdentityRole("HeadDoctor"));
            return View();
        }

        public IActionResult About([FromServices] IEmailSender sender,[FromServices] IPasswordGenerator generator)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
