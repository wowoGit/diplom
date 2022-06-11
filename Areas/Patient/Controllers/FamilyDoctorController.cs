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

namespace testing.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Authorize(Roles = "Patient")]
    public class FamilyDoctorController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        public FamilyDoctorController(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
            : base(configuration.GetConnectionString("PatientConnection"))
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var patient = await _userManager.FindByNameAsync(User.Identity.Name);
            var decl = _context.Declarations.Include(r => r.Doctor).Where(r => r.MedcardId == patient.Id).First();
            ViewData["Doc"] = _context.Doctors.Include(r => r.Department).Include(r => r.Role).Where(r => r.UserId == decl.DoctorId).First();
            var apps = _context.Allmeetings.Where(r => r.MedcardId == patient.Id && r.DocId == decl.DoctorId);
            return View(await apps.ToListAsync());
        }
    }
}
