using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Headdepartment
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
