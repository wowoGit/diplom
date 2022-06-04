using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using testing.Models;
using X.PagedList;

namespace testing.Controllers
{
    public class PublicScheduleController : BaseController
    {

        public PublicScheduleController(IConfiguration configuration):
            base(configuration.GetConnectionString("DefaultConnection"))
        {
        }

        // GET: Schedule
        virtual public async Task<IActionResult> Index(string userId, int? page)
        {
            int page_number = page ?? 1;
            ViewData["UserId"] = userId;
            ViewData["Doctor"] = _context.Doctors.Include(d=>d.Department).Include(d=> d.Role).Where(d => d.UserId == userId).First();
            var dt = await _context.Freeappointmentsweeks.Where(d => d.DoctorId == userId).Select(r => r.DateTime.Date).Distinct().OrderBy(r => r.Date).ToListAsync();
            var model = new List<DaySchedule>();
            foreach(var date in dt)
            {
            var records = _context.Freeappointmentsweeks.Where(r => r.DateTime.Date == date).ToList();
                model.Add(new DaySchedule { Date = date, records = records });
            }
            //var doc_schedule = _context.Freeappointmentsweeks.Select(r => r.DateTime.Date).Distinct()
            //    .Select(key => new DaySchedule{ Date = key, records = _context.Freeappointmentsweeks.Where(r => r.DateTime.Date == key).ToList() });
            var dates_page = model.ToPagedList(page_number, 2);
            return View(dates_page);
        }

        // GET: Schedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedule/Create


        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
