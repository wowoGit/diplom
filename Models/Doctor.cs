using System;
using System.Collections.Generic;

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
        public int DepartmentId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int Experience { get; set; }
        public string About { get; set; }
        public int Cabinet { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Declaration> Declarations { get; set; }
        public virtual ICollection<Headdepartment> Headdepartments { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
