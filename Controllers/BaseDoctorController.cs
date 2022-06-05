using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;
using X.PagedList;

namespace testing.Controllers
{
    [Route("Public/Doctors")]
    public class BaseDoctorController :BaseController
    {
            

        public BaseDoctorController(IConfiguration configuration) 
            :base(configuration.GetConnectionString("DefaultConnection"))
        {
        }
        public virtual async Task<IActionResult> Index(int? page, int? dep)
        {
            int page_number = page ?? 1;
            int dep_id = dep ?? 1;
            var doctors = _context.Doctors.Include(d => d.Department).Include(d => d.Role).Include(d=> d.Schedules).Where(d => d.DepartmentId == dep_id);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name",dep_id);
            var doctors_page = doctors.ToPagedList(page_number, 5);
            return View(doctors_page);
        }
    }
}
