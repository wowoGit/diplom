using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Manager
    {
        public string UserId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
