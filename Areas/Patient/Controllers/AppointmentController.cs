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
        public async Task<IActionResult> Create(int Id)
        {
            var patient = await _userManager.FindByNameAsync(User.Identity.Name);
            var referrals = _context.Referrals.Include(r => r.Department).Where(r => r.DeclarationId == patient.Id);
            ViewData["Referrals"] = new SelectList(referrals, "Id", "Department.Name");

            Appointment app = new Appointment()
            {
                ScheduleId = Id,
                MedcardId = patient.Id
            };
            return View("_PartialAppointment",app);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment app)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("asd");
            }
            return View();
        }
    }
}
