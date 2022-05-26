using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using testing.Models;
using testing.Models;

namespace testing.Controllers
{
    [Area("Manager")]
    //[Authorize(Roles = "Manager")]
    public class PatientController : Controller
    {
        private readonly MedicalContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private string connectionString =
            "host=localhost;database=popmedical_test;username=postgres;password=postgres;";

        public PatientController(MedicalContext Context,
            RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = Context;
        }

        // GET: Manager
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Manager/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Manager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RegisterPatientVM patient)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = patient.Email,
                                                Email = patient.Email,
                                                PhoneNumber = patient.Phone};
                var result = await _userManager.CreateAsync(user, patient.Password);
                await _userManager.AddToRoleAsync(user, "Patient");
                var created_user = await _userManager.FindByEmailAsync(patient.Email);
                var manager_user = await _userManager.FindByEmailAsync("vvs.seal@gmail.com");

                using(NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    NpgsqlCommand command =
                        new NpgsqlCommand("Call create_patient(" +
                        ":userid, :managerid, :fname,:lname,:patro,:dob,:addr,:gen,:bloodt)",con);
                    command.Parameters.AddWithValue("userid",NpgsqlDbType.Text, created_user.Id);
                    command.Parameters.AddWithValue("managerId",NpgsqlDbType.Text, manager_user.Id);
                    command.Parameters.AddWithValue("fname",NpgsqlDbType.Varchar, patient.FirstName);
                    command.Parameters.AddWithValue("lname",NpgsqlDbType.Varchar, patient.LastName);
                    command.Parameters.AddWithValue("patro",NpgsqlDbType.Varchar, patient.Patronymic);
                    command.Parameters.AddWithValue("dob",NpgsqlDbType.Date, patient.DateOfBirth);
                    command.Parameters.AddWithValue("addr",NpgsqlDbType.Varchar, patient.Address);
                    command.Parameters.AddWithValue("gen", patient.Gender);
                    command.Parameters.AddWithValue("bloodt", patient.BloodType);

                    var reader = command.ExecuteReader();
                }
                //_context.Add(patient);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Manager/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,SignDate,Firstname,Lastname,Patronymic,DateOfBirth,Address")] Patient patient)
        {
            if (id != patient.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.UserId))
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
            return View(patient);
        }

        // GET: Manager/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(string id)
        {
            return _context.Patients.Any(e => e.UserId == id);
        }
    }
}
