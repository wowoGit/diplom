using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testing.ViewModels
{
    public class ScheduleVM
    {
        public string DoctorId { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}
