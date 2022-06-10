using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Models;

namespace testing.ViewModels
{
    public class ScheduleListVM
    {
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }
        public List<Weekschedule> Weekschedules { get; set; }
    }
}
