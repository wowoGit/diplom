using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Department
    {
        public Department()
        {
            Doctors = new HashSet<Doctor>();
            Referrals = new HashSet<Referral>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Referral> Referrals { get; set; }
    }
}
