using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using testing.Controllers;
using testing.Models;
using testing.Services;
using X.PagedList;

namespace testing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : BaseController
    {

        public DoctorController(IConfiguration configuration):
            base(configuration.GetConnectionString("AdminConnection"))
        {
        }

        // GET: Admin/Doctor

        // GET: Admin/Doctor/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Admin/Doctor/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Name");
            return View();
        }

        // POST: Admin/Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromServices] IPasswordGenerator generator,[FromServices] IEmailSender sender,[FromServices] IDoctorCreationService creation_service, RegisterDoctorVM doctor)
        {
            if (ModelState.IsValid)
            {
                var result = await creation_service.CreateDoctor(generator, sender,doctor);
                if(result.Succeeded) {
                    RedirectToAction(nameof(Index));
                }
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", doctor.DepartmentId);
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Name", doctor.RoleId);
            return View(doctor);
        }

        // GET: Admin/Doctor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", doctor.DepartmentId);
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Name", doctor.RoleId);
            return View(doctor);
        }

        // POST: Admin/Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,DepartmentId,EmploymentDate,Experience,About,Cabinet,Firstname,Lastname,Patronymic,DateOfBirth,Address,RoleId")] RegisterDoctorVM doctor)
        {
            //if (id != doctor.UserId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!DoctorExists(doctor.UserId))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", doctor.DepartmentId);
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Name", doctor.RoleId);
            return View(doctor);
        }

        // GET: Admin/Doctor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Admin/Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doctor = await _context.Users.FindAsync(id);
            _context.Users.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(string id)
        {
            return _context.Doctors.Any(e => e.UserId == id);
        }
    }
}
