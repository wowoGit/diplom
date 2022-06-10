using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testing.Models;
using testing.Services;
using testing.ViewModels;

namespace testing.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles ="Doctor,HeadDoctor")]
    public class ScheduleController : Controller
    {
        private readonly MedicalContext _context;

        public ScheduleController(MedicalContext context)
        {
            _context = context;
        }

        // GET: Doctor/Schedule
        [Authorize(Roles ="HeadDoctor")]
        public async Task<IActionResult> Index([FromServices] UserManager<IdentityUser> userManager)
        {
            var auth_doc = await userManager.FindByNameAsync(User.Identity.Name);
            var doc_record = _context.Doctors.Include(d => d.Department).Where(s => s.UserId == auth_doc.Id).First();
            var schedule = await _context.Weekschedules.ToListAsync();

            ViewData["Department"] = doc_record.Department.Name;
            var schedule_grouped = schedule.GroupBy(s => new { s.DocId, s.DateTime.Date })
                .OrderBy(s => s.Key.Date)
                .Select(s => new ScheduleListVM
                {
                    DoctorId = s.Key.DocId,
                    Date = s.Key.Date,
                    Weekschedules = s.ToList()
                });
            return View(schedule_grouped);
        }

        // GET: Doctor/Schedule/Details/5
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

        // GET: Doctor/Schedule/Create
        [Authorize(Roles ="HeadDoctor")]
        public async Task<IActionResult> CreateAsync([FromServices] UserManager<IdentityUser> userManager)
        {
            var AuthorizedDoctor = await userManager.FindByNameAsync(User.Identity.Name);
            var AuthorizedDoctorRecord = _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .Where(d => d.UserId == AuthorizedDoctor.Id).First();

            ViewData["DoctorId"] = await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .Where(d => d.Department.Name == AuthorizedDoctorRecord.Department.Name)
                .Select(s => new SelectListItem
                {
                    Text = s.Lastname + ' ' + s.Firstname + ' ' + s.Patronymic + '(' + s.Role.Name + ')' ,
                    Value = s.UserId
                }).ToListAsync();
            return View();
        }

        // POST: Doctor/Schedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="HeadDoctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromServices] UserManager<IdentityUser> userManager,[FromServices] IScheduleCreator ScheduleCreator, ScheduleVM scheduleViewModel)
        {
            TempData["Notify"] = true;
            var AuthorizedDoctor = await userManager.FindByNameAsync(User.Identity.Name);
            var AuthorizedDoctorRecord = _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .Where(d => d.UserId == AuthorizedDoctor.Id).First();

            if (ModelState.IsValid)
            {
                var doctor = scheduleViewModel.DoctorId;
                var shift_start = scheduleViewModel.DateTimeStart;
                var shift_end = scheduleViewModel.DateTimeEnd;
                if (ScheduleCreator.CreateScheduleForDoctor(doctor, shift_start, shift_end))
                {
                    TempData["Success"] = true;        
                    TempData["Message"] = "Смена успешно создана!";        
                } 
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = "Ошибка при создании смены! Проверьте корректность данных.";
            ViewData["DoctorId"] = await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .Where(d => d.Department.Name == AuthorizedDoctorRecord.Department.Name)
                .Select(s => new SelectListItem
                {
                    Text = s.Lastname + ' ' + s.Firstname + ' ' + s.Patronymic + '(' + s.Role.Name + ')' ,
                    Value = s.UserId
                }).ToListAsync();

            return View(scheduleViewModel);
        }

        // GET: Doctor/Schedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "UserId", "UserId", schedule.DoctorId);
            return View(schedule);
        }

        // POST: Doctor/Schedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,DateTime")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "UserId", "UserId", schedule.DoctorId);
            return View(schedule);
        }

        // GET: Doctor/Schedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Doctor/Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
