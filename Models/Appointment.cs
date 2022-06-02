using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace testing.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string MedcardId { get; set; }
        public int ScheduleId { get; set; }
        [Display(Name ="Жалоба")]
        public string Info { get; set; }
        public int? ReferralId { get; set; }

        public virtual Medcard Medcard { get; set; }
        public virtual Referral Referral { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual History History { get; set; }
    }
}
