using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Weekschedule
    {
        public string DoctorFname { get; set; }
        public string DoctorLname { get; set; }
        public string DoctorPatronymic { get; set; }
        public int? Experience { get; set; }
        public DateTime? DateTime { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string Info { get; set; }
        public int? ReferralId { get; set; }
    }
}
