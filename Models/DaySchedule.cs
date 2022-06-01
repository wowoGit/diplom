using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public class DaySchedule
    {
        public DateTime Date { get; set; }
        public List<Freeappointmentsweek> records { get; set; }
    }
}
