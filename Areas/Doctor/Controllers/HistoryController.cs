using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using testing.Controllers;
using testing.Models;
using testing.ViewModels;

namespace testing.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class HistoryController : BaseController
    {
        public HistoryController(IConfiguration configuration)
            : base(configuration.GetConnectionString("DoctorConnection"))
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HistoryVM model)
        {
            TempData["Notify"] = true;
            if (ModelState.IsValid)
            {
                try
                {

                    var history = new History
                    {
                        AppointmentId = model.appointmentId,
                        Diagnosis = model.Diagnosis
                    };
                    _context.Histories.Add(history);
                    model.HProcedures.AddRange(model.HProcedures);
                    model.HDocuments.AddRange(model.HDocuments);
                    model.HMedications.AddRange(model.HMedications);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = true;
                    TempData["Message"] = "Прием успешно обраборан!";
                }

                catch (Exception e)
                {
                    TempData["Message"] = "Произошла ошибка при обработке приема";
                    return RedirectToAction("Details", "Appointment", new { area = "Doctor", id = model.appointmentId });
                }
                
            }
            return RedirectToAction("Index","Appointment",new { area = "Doctor" });
        }

        public PartialViewResult AddDocument(int h_id)
        {
            ViewData["Documents"] = new SelectList(_context.Documents, "Id", "Name");
            var doc = new Historydocument 
                {
                HistoryId = h_id
                };
            return PartialView("_AddDocument",doc);
        }
        public PartialViewResult AddMedication(int h_id)
        {
            ViewData["Medication"] = new SelectList(_context.Medications, "Id", "Name");
            var med = new Historymedication 
                {
                HistoryId = h_id
                };
            return PartialView("_AddMedication", med);
        }
        public PartialViewResult AddProcedure(int h_id)
        {
            ViewData["Procedure"] = new SelectList(_context.Procedures, "Id", "Name");
            var proc = new Historyprocedure 
                {
                HistoryId = h_id
                };
            return PartialView("_AddProcedure",proc);
        }
    }
}
