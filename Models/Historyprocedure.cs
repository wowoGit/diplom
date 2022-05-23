using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Historyprocedure
    {
        public int HistoryId { get; set; }
        public int ProcedureId { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }

        public virtual History History { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
}
