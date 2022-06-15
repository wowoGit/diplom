using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Medcard
    {
        public Medcard()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string PatientId { get; set; }
        public string ManagerId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiredDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Declaration Declaration { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
