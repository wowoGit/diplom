using Microsoft.AspNetCore.Mvc;
using testing.ViewModels;

namespace testing.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HistoryVM model)
        {
            return View();
        }
    }
}
