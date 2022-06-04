using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Controllers
{
    [Route("Doctor")]
    public class BaseDoctorController :BaseController
    {
            

        public BaseDoctorController(IConfiguration configuration) 
            :base(configuration.GetConnectionString("DefaultConnection"))
        {
        }
    }
}
