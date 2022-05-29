using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace testing.Models
{
    public partial class Patient
    {
        public string UserId { get; set; }

        [Display(Name ="Дата регистрации")]
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }
        [Display(Name ="Имя")]
        public string Firstname { get; set; }
        [Display(Name ="Фамилия")]
        public string Lastname { get; set; }
        [Display(Name ="Отчество")]
        public string Patronymic { get; set; }
        [Display(Name ="Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name ="Адрес проживания")]
        public string Address { get; set; }
        [Display(Name ="Пол")]
        public Gender Gender { get; set; }
        [Display(Name ="Группа крови")]
        public BloodType BloodType { get; set; }

        public virtual Medcard Medcard { get; set; }
    }
}
