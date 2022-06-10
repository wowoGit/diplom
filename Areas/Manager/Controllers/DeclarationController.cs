using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using testing.Controllers;
using testing.Models;
using X.PagedList;

namespace testing.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class DeclarationController : BaseController
    {

        public DeclarationController(IConfiguration configuration, MedicalContext context)
            :base(configuration.GetConnectionString("ManagerConnection"))
        {
        }

        // GET: Manager/Declaration
        public async Task<IActionResult> Index(int? page)
        {
            var page_num = page ?? 1;
            var medicalContext = await _context.Declarations
                .Include(d => d.Doctor)
                .Include(d => d.Medcard)
                .Include(d => d.Medcard.Patient)
                .ToListAsync();
            var list_page = medicalContext.ToPagedList(1, 10);
            return View(list_page);
        }

        // GET: Manager/Declaration/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations
                .Include(d => d.Doctor)
                .Include(d => d.Medcard)
                .FirstOrDefaultAsync(m => m.MedcardId == id);
            if (declaration == null)
            {
                return NotFound();
            }

            return View(declaration);
        }

        // GET: Manager/Declaration/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["DoctorId"] = await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .Where(d => d.Department.Name == "Семейная практика")
                .Select(s => new SelectListItem
                {
                    Text = s.Lastname + ' ' + s.Firstname + ' ' + s.Patronymic + '(' + s.Role.Name + ')' ,
                    Value = s.UserId
                }).ToListAsync();
            ViewData["MedcardId"] = await _context.Freepatients
                .Select(s => new SelectListItem
                {
                    Text = s.Lastname + ' ' + s.Firstname + ' ' + s.Patronymic + '(' + s.DateofBirth.ToShortDateString() + ')' ,
                    Value = s.Pid
                }).ToListAsync();
            var dec = new Declaration
            {
                SignDate = DateTime.Now
            };
            return View(dec);
        }

        // POST: Manager/Declaration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedcardId,DoctorId,SignDate")] Declaration declaration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(declaration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .Where(d => d.Department.Name == "Семейная практика")
                .Select(s => new SelectListItem
                {
                    Text = s.Lastname + ' ' + s.Firstname + ' ' + s.Patronymic + '(' + s.Role.Name + ')' ,
                    Value = s.UserId
                }).ToListAsync();
            ViewData["MedcardId"] = await _context.Freepatients
                .Select(s => new SelectListItem
                {
                    Text = s.Lastname + ' ' + s.Firstname + ' ' + s.Patronymic + '(' + s.DateofBirth.ToShortDateString() + ')' ,
                    Value = s.Pid
                }).ToListAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Manager/Declaration/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations.FindAsync(id);
            if (declaration == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "UserId", "UserId", declaration.DoctorId);
            ViewData["MedcardId"] = new SelectList(_context.Medcards, "PatientId", "PatientId", declaration.MedcardId);
            return View(declaration);
        }

        // POST: Manager/Declaration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MedcardId,DoctorId,SignDate")] Declaration declaration)
        {
            if (id != declaration.MedcardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(declaration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeclarationExists(declaration.MedcardId))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "UserId", "UserId", declaration.DoctorId);
            ViewData["MedcardId"] = new SelectList(_context.Medcards, "PatientId", "PatientId", declaration.MedcardId);
            return View(declaration);
        }

        // GET: Manager/Declaration/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations
                .Include(d => d.Doctor)
                .Include(d => d.Medcard)
                .FirstOrDefaultAsync(m => m.MedcardId == id);
            if (declaration == null)
            {
                return NotFound();
            }

            return View(declaration);
        }

        // POST: Manager/Declaration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var declaration = await _context.Declarations.FindAsync(id);
            _context.Declarations.Remove(declaration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeclarationExists(string id)
        {
            return _context.Declarations.Any(e => e.MedcardId == id);
        }
    }
}
