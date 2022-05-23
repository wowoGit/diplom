using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string DoctorId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
