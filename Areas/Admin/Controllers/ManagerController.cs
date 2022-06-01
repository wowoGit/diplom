using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testing.Models;

namespace testing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagerController : Controller
    {
        private readonly MedicalContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ManagerController(MedicalContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/Manager
        public async Task<IActionResult> Index()
        {
            return View(await _context.Managers.ToListAsync());
        }

        // GET: Admin/Manager/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // GET: Admin/Manager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Manager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterUserVM manager)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    PhoneNumber = manager.Phone,
                    Email = manager.Email,
                    UserName = manager.Email
                };
                var result = await _userManager.CreateAsync(user, manager.Password);
                if (result.Succeeded)
                {
                    Models.Manager mngr = new()
                    {
                        Firstname = manager.FirstName,
                        Lastname = manager.LastName,
                        Patronymic = manager.Patronymic,
                        DateOfBirth = manager.DateOfBirth,
                        Address = manager.Address,
                        Gender = manager.Gender,
                        EmploymentDate = DateTime.Now,
                        UserId = user.Id
                    };
                _context.Add(mngr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            }
            return View(manager);
        }

        // GET: Admin/Manager/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }
            return View(manager);
        }

        // POST: Admin/Manager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,RegisterUserVM manager)
        {
            //if (id != manager.UserId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ManagerExists(manager.UserId))
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
            return View(manager);
        }

        // GET: Admin/Manager/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // POST: Admin/Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var manager = await _context.Managers.FindAsync(id);
            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerExists(string id)
        {
            return _context.Managers.Any(e => e.UserId == id);
        }
    }
}
