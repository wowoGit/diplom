using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Patient
    {
        public string UserId { get; set; }
        public DateTime SignDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public virtual Medcard Medcard { get; set; }
    }
}
