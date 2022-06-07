using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PasswordGenerator;

namespace testing.Services
{
    public class PassGenerator : IPasswordGenerator
    {
        public string GeneratePassword(int length)
        {
            return new Password(length).IncludeUppercase().IncludeNumeric().Next();
        }
    }
}
