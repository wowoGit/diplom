using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Historydocument
    {
        public int HistoryId { get; set; }
        public int DocumentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Document Document { get; set; }
        public virtual History History { get; set; }
    }
}
