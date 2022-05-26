using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public class RegisterPatientVM
    {
        [Required]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
 
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Адрес проживания")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Группа крови")]
        public BloodType BloodType { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
