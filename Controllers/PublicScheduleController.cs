using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testing.Models;

namespace testing.Controllers
{
    public class PublicScheduleController : Controller
    {
        private readonly MedicalContext _context;

        public PublicScheduleController(MedicalContext context)
        {
            _context = context;
        }

        // GET: Schedule
        virtual public async Task<IActionResult> Index()
        {
            var medicalContext = _context.Schedules.Include(s => s.Doctor);
            return View(await medicalContext.ToListAsync());
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
