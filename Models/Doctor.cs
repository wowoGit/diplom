using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using testing.Extensions;

#nullable disable

namespace testing.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Declarations = new HashSet<Declaration>();
            Headdepartments = new HashSet<Headdepartment>();
            Schedules = new HashSet<Schedule>();
        }

        public string UserId { get; set; }
        [Display(Name = "Отделение")]
        public int DepartmentId { get; set; }
        public DateTime EmploymentDate { get; set; }
        [Display(Name = "Опыт работы")]
        public int Experience { get; set; }
        [Display(Name = "Краткая биография")]
        public string About { get; set; }
        [Display(Name = "Приемный кабинет")]
        public int Cabinet { get; set; }
        [Display(Name = "Имя")]
        public string Firstname { get; set; }
        [Display(Name = "Фамилия")]
        public string Lastname { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Должность")]
        public int RoleId { get; set; }

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Отделение")]
        public virtual Department Department { get; set; }
        [Display(Name = "Должность")]
        public virtual Role Role { get; set; }
        public virtual ICollection<Declaration> Declarations { get; set; }
        public virtual ICollection<Headdepartment> Headdepartments { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
