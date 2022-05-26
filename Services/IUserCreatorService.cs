using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Services
{
    interface IUserCreatorService
    {
        IdentityUser CreateUser(RegisterUserVM user);
    }
}
