using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Controllers;
using testing.ViewModels;

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
            var doc_app = await _context.Weekschedules.Where(r => r.DocId == logged_doc.Id && r.DateTime.Date == DateTime.Now.Date && r.AppId != null).ToListAsync();
            return View(doc_app);
        }
        public IActionResult Details(int id)
        {
            ViewData["Departments"] = new SelectList(_context.Departments, "Id", "Name");
            var app_record = _context.Appointments
                .Include(a => a.Medcard)
                .Include(a => a.Schedule)
                .Include(a => a.Referral)
                .Include(a => a.Medcard.Patient)
                .Where(a => a.Id == id).FirstOrDefault();
            ViewData["app"] = app_record;
            ViewData["HId"] = app_record.Id;
            var historyViewModel = new HistoryVM { appointmentId = id };
            ViewData["Documents"] = new SelectList(_context.Documents, "Id", "Name");
            ViewData["Medication"] = new SelectList(_context.Medications, "Id", "Name");
            ViewData["Procedure"] = new SelectList(_context.Procedures, "Id", "Name");
            return View(historyViewModel);
        }
    }
}
