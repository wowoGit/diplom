using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using testing.Controllers;
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
        public IActionResult Create(HistoryVM model)
        {
            return View();
        }

        public PartialViewResult AddDocument()
        {
            ViewData["Documents"] = new SelectList(_context.Documents, "Id", "Name");
            return PartialView("_AddDocument");
        }
        public PartialViewResult AddMedication()
        {
            return PartialView("_AddMedication");
        }
        public PartialViewResult AddProcedure()
        {
            return PartialView("_AddProcedure");
        }
    }
}
