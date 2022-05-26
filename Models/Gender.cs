using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public enum Gender
    {
        [Display(Name = "Мужской")]
        male,
        [Display(Name = "Женский")]
        female
    }
}
