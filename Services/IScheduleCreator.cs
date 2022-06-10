using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Services
{
    public interface IScheduleCreator
    {
        bool CreateScheduleForDoctor(string doctorId, DateTime start, DateTime end);
    }
}
