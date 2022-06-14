using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace testing.Models
{
    public partial class Completedmeeting
    {
        public int Id { get; set; }
        [Column("p_id")]
        public string PatientId { get; set; }
        [Column("d_id")]
        public string DoctorId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Patronymic { get; set; }
        [Display(Name="Диагноз")]
        public string Diag { get; set; }
        public string Doc { get; set; }
        public DateTime? Dateo { get; set; }
        public DateTime? Datec { get; set; }
        [Display(Name="Дата приема")]
        public DateTime App_date { get; set; }
        [Display(Name="Жалоба")]
        public string App_info { get; set; }
        [Display(Name="Имя")]
        public string D_fname { get; set; }
        [Display(Name="Фамилия")]
        public string D_lname { get; set; }
        [Display(Name = "Отчество")]
        public string D_patro { get; set; }
        public string Pname { get; set; }
        public string Proc_result { get; set; }
        public DateTime? Dateop { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
    }
}
