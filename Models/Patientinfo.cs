using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Patientinfo
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string FamilyDoctorFname { get; set; }
        public string FamilyDoctorLname { get; set; }
        public string FamilyDoctorPatro { get; set; }
        public DateTime? SignDate { get; set; }
    }
}
