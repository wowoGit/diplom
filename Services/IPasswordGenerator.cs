using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PasswordGenerator;


namespace testing.Services
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int length);
    }
}
