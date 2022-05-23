using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Historymedication
    {
        public int HistoryId { get; set; }
        public int MedicationId { get; set; }
        public string Dose { get; set; }

        public virtual History History { get; set; }
        public virtual Medication Medication { get; set; }
    }
}
