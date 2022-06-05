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
    [Area("Doctor")]
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
        public async  Task<IActionResult> Index()
        {
            var logged_doc = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["doc_info"] = _context.Doctors.Where(d => d.UserId == logged_doc.Id).First();
            ViewData["schedule_info"] = await _context.Schedules.Where(s => s.DoctorId == logged_doc.Id && s.DateTime.Date == DateTime.Now.Date).OrderBy(s => s.DateTime).ToListAsync();
            var doc_app = await _context.Weekschedules.Where(r => r.DocId == logged_doc.Id).ToListAsync();
            return View(doc_app);
        }
        public async  Task<IActionResult> Details(int id)
        {
            var logged_doc = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["doc_info"] = _context.Doctors.Where(d => d.UserId == logged_doc.Id).First();
            ViewData["schedule_info"] = await _context.Schedules.Where(s => s.DoctorId == logged_doc.Id && s.DateTime.Date == DateTime.Now.Date).OrderBy(s => s.DateTime).ToListAsync();
            var doc_app = await _context.Weekschedules.Where(r => r.DocId == logged_doc.Id).ToListAsync();
            return View(doc_app);
        }
    }
}
