using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Referral
    {
        public Referral()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string DeclarationId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime IssuedDate { get; set; }

        public virtual Declaration Declaration { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
