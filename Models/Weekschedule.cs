using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace testing.Models
{
    public partial class Weekschedule
    {
        public string DoctorFname { get; set; }
        public string DoctorLname { get; set; }
        public string DoctorPatronymic { get; set; }
        [Column("role_name")]
        public string RoleName { get; set; }
        [Column("dep_name")]
        public string DepName { get; set; }
        public DateTime DateTime { get; set; }
        [Column("gender")]
        public Gender? PatientGender { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Patronymic { get; set; }
        public string? Info { get; set; }
        [Column("doc_id")]
        public string DocId { get; set; }
        [Column("p_birth")]
        public DateTime? PatientBirth { get; set; }
        public int? ReferralId { get; set; }
        [Column("history_id")]
        public int? HistoryId { get; set; }
        [Column("app_id")]
        public int? AppId { get; set; }
    }
}
