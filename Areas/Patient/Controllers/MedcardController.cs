using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testing.Models;

namespace testing.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class MedcardController : Controller
    {
        private readonly MedicalContext _context;

        public MedcardController(MedicalContext context)
        {
            _context = context;
        }

        // GET: Patient/Medcard
        public async Task<IActionResult> Index()
        {
            var medicalContext = _context.Medcards.Include(m => m.Patient);
            return View(await medicalContext.ToListAsync());
        }

        // GET: Patient/Medcard/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medcard = await _context.Medcards
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (medcard == null)
            {
                return NotFound();
            }

            return View(medcard);
        }

        // GET: Patient/Medcard/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "UserId", "UserId");
            return View();
        }

        // POST: Patient/Medcard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,ManagerId,IssuedDate,ExpiredDate")] Medcard medcard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medcard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "UserId", "UserId", medcard.PatientId);
            return View(medcard);
        }

        // GET: Patient/Medcard/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medcard = await _context.Medcards.FindAsync(id);
            if (medcard == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "UserId", "UserId", medcard.PatientId);
            return View(medcard);
        }

        // POST: Patient/Medcard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PatientId,ManagerId,IssuedDate,ExpiredDate")] Medcard medcard)
        {
            if (id != medcard.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medcard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedcardExists(medcard.PatientId))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "UserId", "UserId", medcard.PatientId);
            return View(medcard);
        }

        // GET: Patient/Medcard/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medcard = await _context.Medcards
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (medcard == null)
            {
                return NotFound();
            }

            return View(medcard);
        }

        // POST: Patient/Medcard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medcard = await _context.Medcards.FindAsync(id);
            _context.Medcards.Remove(medcard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedcardExists(string id)
        {
            return _context.Medcards.Any(e => e.PatientId == id);
        }
    }
}
