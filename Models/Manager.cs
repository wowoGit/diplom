using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace testing.Models
{
    public partial class Manager
    {
        public string UserId { get; set; }
        [Display(Name ="Дата приема на работу")]
        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }
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
        [Display(Name = "gender")]
        [Column("gender")]
        public Gender Gender { get; set; }
    }
}
