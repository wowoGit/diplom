using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.Models
{
    public class MedcardVM
    {
        public IdentityUser user_info { get; set; }
        public Medcard user_medcard { get; set; }
    }
}
