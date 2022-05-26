using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public class RegisterDoctorVM : RegisterUserVM
    {
        [Required]
        [Display(Name = "Должность")]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Опыт работы")]
        public int Experience { get; set; }

        [Required]
        [Display(Name = "Приемный кабинет")]
        public int Cabinet { get; set; }

        [Required]
        [Display(Name = "Краткая биография")]
        public string About { get; set; }

        [Required]
        [Display(Name = "Отделение")]
        public int DepartmentId { get; set; }
        public static explicit operator Doctor(RegisterDoctorVM doctorVM)
        {
            return new Doctor
            {
                Firstname = doctorVM.FirstName,
                Lastname = doctorVM.LastName,
                Patronymic = doctorVM.Patronymic,
                DateOfBirth = doctorVM.DateOfBirth,
                DepartmentId = doctorVM.DepartmentId,
                RoleId = doctorVM.RoleId,
                Address = doctorVM.Address,
                Gender = doctorVM.Gender,
                About = doctorVM.About,
                Experience = doctorVM.Experience,
                Cabinet = doctorVM.Cabinet,
            };
        }
    }
}
