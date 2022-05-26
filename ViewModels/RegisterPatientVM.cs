using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public class RegisterPatientVM : RegisterUserVM
    {
        [Required]
        [Display(Name = "Группа крови")]
        public BloodType BloodType { get; set; }
    }
}
