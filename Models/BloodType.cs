using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public enum BloodType
    {
        [PgName("ZERO_plus")]
        [Display(Name = "Первая+")]
        ZERO_plus,
        [PgName("ZERO_minus")]
        [Display(Name = "Первая-")]
        ZERO_minus,
        [PgName("A_plus")]
        [Display(Name = "Вторая+")]
        A_plus,
        [PgName("A_minus")]
        [Display(Name = "Вторая-")]
        A_minus,
        [PgName("B_plus")]
        [Display(Name = "Третья+")]
        B_plus,
        [PgName("B_minus")]
        [Display(Name = "Третья-")]
        B_minus,
        [PgName("AB_plus")]
        [Display(Name = "Четвертая+")]
        AB_plus,
        [PgName("AB_minus")]
        [Display(Name = "Четвертая-")]
        AB_minus,
    }
}
