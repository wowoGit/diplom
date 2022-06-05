using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Controllers;

namespace testing.Areas.Doctor.Controllers
{
    public class AppointmentController : BaseController 
    {
        UserManager<IdentityUser> _userManager;
        public AppointmentController(
            IConfiguration configuration, 
            UserManager<IdentityUser> userManager)
            : base(configuration.GetConnectionString("DoctorConnection"))
        {
            _userManager = userManager;
        }
        [Authorize(Roles ="HeadDoctor")]
        public async  Task<IActionResult> Index()
        {
            var logged_doc = await _userManager.FindByNameAsync(User.Identity.Name);
            int doc_dep = _context.Doctors.Where(d => d.UserId == logged_doc.Id).Select(d => d.DepartmentId).First();
            var dep_doctors = await _context.Schedules.Include(s => s.Doctor).Where(d => d.Doctor.DepartmentId == doc_dep).ToListAsync();
            return View();
        }
    }
}
