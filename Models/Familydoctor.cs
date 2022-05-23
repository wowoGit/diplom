using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Familydoctor
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public int? Experience { get; set; }
        public long? TotalPatients { get; set; }
        public string PatientFname { get; set; }
        public string PatientLname { get; set; }
        public string PatientPatro { get; set; }
        public DateTime? SignDate { get; set; }
    }
}
