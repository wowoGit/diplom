using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Services
{
    public interface IDoctorCreationService
    {
        public Task<IdentityResult> CreateDoctor([FromServices] IPasswordGenerator generator,[FromServices] IEmailSender sender,RegisterDoctorVM doctor);
    }
}
