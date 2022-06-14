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

namespace testing.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class AppointmentController : BaseController
    {
        public AppointmentController(IConfiguration configuration)
            :base(configuration.GetConnectionString("ManagerConnection"))
        {

        }
        [HttpPost]
        public IActionResult Create(string medcardId, int scheduleId, int referralId, string info)
        {
            return View();
        }

        public async Task<IActionResult> Create(int ScheduleId, string DoctorId)
        {
            //ViewData["Referrals"] = new SelectList(referrals, "Id", "Department.Name");
            ViewData["app_time"] = _context.Schedules.Where(m => m.Id == ScheduleId);
            var doc = _context.Doctors.Include(d => d.Department).Where(d => d.UserId == DoctorId).First();
            var doc_dep = doc.DepartmentId;
            ViewData["doc"] = doc;
            //ViewData["HasReferral"] = _context.Activereferrals.Where(e => e.DeclarationId == patient.Id && doc_dep == e.DepartmentId).FirstOrDefault();
            Appointment app = new Appointment()
            {
                ScheduleId = ScheduleId,
            };
            ViewData["MedcardId"] = await _context.Patients
                .Select(s => new SelectListItem
                {
                    Text = s.Lastname + ' ' + s.Firstname + ' ' + s.Patronymic + '(' + s.DateOfBirth.ToShortDateString() + ')' ,
                    Value = s.UserId
                }).ToListAsync();
            app.Schedule = _context.Schedules.Include(d => d.Doctor).Where(m => m.Id == ScheduleId).FirstOrDefault();
            return View("_PartialAppointment",app);        }
    }
}
