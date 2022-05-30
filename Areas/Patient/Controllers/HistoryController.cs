﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;
using X.PagedList;

namespace testing.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HistoryController : Controller
    {
        public readonly MedicalContext _context;
        public readonly UserManager<IdentityUser> _userManager;
        public HistoryController(MedicalContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int? page)
        {
            var page_number = page ?? 1;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var user_history = _context.Histories.Include(h => h.Appointment)
            //    .ThenInclude(a => a.Schedule)
            //    .ThenInclude(s => s.Doctor)
            //    .ThenInclude(d => d.Department).Where(m => m.Appointment.MedcardId == user.Id);
            var user_history = _context.Allmeetings.Where(model => model.MedcardId == user.Id).OrderByDescending(m => m.Appdate);
            var user_history_page = user_history.ToPagedList(page_number, 3);
            return View(user_history_page);
        }
        public async Task<IActionResult> Details(int id)
        {
            var history_record = await _context.Completedmeetings.Where(h => h.Id == id).ToListAsync();
                return View(history_record);
        }
    }
}