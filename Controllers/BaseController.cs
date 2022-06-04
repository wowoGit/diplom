using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly MedicalContext _context;

        public BaseController(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MedicalContext>();
            var options = optionsBuilder.UseNpgsql(connectionString).Options;
            _context = new MedicalContext(options);
        }
    }
}
