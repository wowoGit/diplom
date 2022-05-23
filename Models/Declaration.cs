using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Declaration
    {
        public Declaration()
        {
            Referrals = new HashSet<Referral>();
        }

        public string MedcardId { get; set; }
        public string DoctorId { get; set; }
        public DateTime SignDate { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Medcard Medcard { get; set; }
        public virtual ICollection<Referral> Referrals { get; set; }
    }
}
