using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class AppointmentController : Controller
    {
        private readonly MedicalContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentController(MedicalContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int ScheduleId,string DoctorId)
        {
            var patient = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewData["Referrals"] = new SelectList(referrals, "Id", "Department.Name");
            ViewData["app_time"] = _context.Schedules.Where(m => m.Id == ScheduleId);
            var doc = _context.Doctors.Include(d => d.Department).Where(d => d.UserId == DoctorId).First();
            var doc_dep = doc.DepartmentId;
            ViewData["doc"] = doc;
            ViewData["HasReferral"] = _context.Activereferrals.Where(e => e.DeclarationId == patient.Id && doc_dep == e.DepartmentId).FirstOrDefault();
            Appointment app = new Appointment()
            {
                ScheduleId = ScheduleId,
                MedcardId = patient.Id,
            };
            app.Schedule = _context.Schedules.Include(d => d.Doctor).Where(m => m.Id == ScheduleId).FirstOrDefault();
            return View("_PartialAppointment",app);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment app)
        {
            if (ModelState.IsValid)
            {
                TempData["AppInfo"] = true;
                try
                {
                _context.Appointments.Add(app);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Прием успешно зарегистрирован!"; 
                TempData["Success"] = true; 
                }
                catch(Exception e)
                {
                    TempData["Message"] = e.InnerException?.Message;
                }
            }
            return RedirectToAction("Index","PublicSchedule", new { area= "" });
        }
    }
}
