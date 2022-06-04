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

namespace testing.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IConfiguration configuration)
            :base(configuration.GetConnectionString("DefaultConnection"))
        {

        }

        public IActionResult Index()
        {
            //var user = new IdentityUser { Email = "patient@gmail.com", UserName = "patient@gmail.com" };
            //await _userManager.CreateAsync(user, "123123");
            //await _userManager.AddToRoleAsync(user, "Patient");
            return View();
        }

        public IActionResult About()
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
