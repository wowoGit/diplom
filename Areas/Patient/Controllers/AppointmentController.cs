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
using testing.Models;

namespace testing.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class AppointmentController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentController(IConfiguration configuration, UserManager<IdentityUser> userManager) :
            base(configuration.GetConnectionString("PatientConnection"))
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int ScheduleId, string DoctorId)
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
            return View("_PartialAppointment", app);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment app)
        {
            string docId = _context.Schedules.Where(s => s.Id == app.ScheduleId).Select(s => s.DoctorId).First();
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
                catch (Exception e)
                {
                    TempData["Message"] = e.InnerException?.Message;
                }
            }
            return RedirectToAction("Index", "PublicSchedule", new { area = "", userId = docId });
        }
        public async Task<IActionResult> CreateFamilyApp(string DoctorId)
        {
            var dt = await _context.Freeappointmentsweeks.Where(d => d.DoctorId == DoctorId).Select(r => r.DateTime.Date).Distinct().OrderBy(r => r.Date).ToListAsync();
            var model = new List<DaySchedule>();
            foreach (var date in dt)
            {
                var records = _context.Freeappointmentsweeks.Where(r => r.DateTime.Date == date && r.DoctorId == DoctorId).ToList();
                model.Add(new DaySchedule { Date = date, records = records });
            }

            return View("_TabbedAppointment", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFamApp(int ScheduleId, string Info, string returnUrl)
        {
            var auth_patient = await _userManager.FindByNameAsync(User.Identity.Name);
            var app = new Appointment
            {
                ScheduleId = ScheduleId,
                Info = Info,
                MedcardId = auth_patient.Id
            };
            _context.Appointments.Add(app);
            await _context.SaveChangesAsync();
            return Redirect(returnUrl);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var app = _context.Appointments.Where(r => r.Id == id).First();
            _context.Appointments.Remove(app);
            await _context.SaveChangesAsync();
            return Redirect("/Patient/History");
        }
    }
}
