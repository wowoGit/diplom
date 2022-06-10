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
    [Authorize(Roles = "Doctor")]
    public class DeclarationController : BaseController
    {
        public DeclarationController(IConfiguration configuration)
            : base(configuration.GetConnectionString("DoctorConnection"))
        {

        }
        public async Task<IActionResult> Index([FromServices] UserManager<IdentityUser> userManager)
        {
            var auth_doc = await userManager.FindByNameAsync(User.Identity.Name);
            ViewData["TotalPatients"] = _context.Familydoctors.Where(r => r.UserId == auth_doc.Id).Count();
            var declarations = _context.Declarations
                .Include(r => r.Doctor)
                .Include(r => r.Medcard)
                .Include(r => r.Medcard.Patient)
                .Where(r => r.DoctorId == auth_doc.Id);
            return View(await declarations.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Confirm(string id, string returnUrl)
        {
            var record = _context.Declarations.Where(r => r.MedcardId == id).First();
            record.Confirmed = true;
            await _context.SaveChangesAsync();
            return Redirect(returnUrl);
        }
    }
}
