using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }
        [Column("confirmed")]
        public bool Confirmed { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Medcard Medcard { get; set; }
        public virtual ICollection<Referral> Referrals { get; set; }
    }
}
