using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Services
{
    public class ScheduleCreator : IScheduleCreator
    {
        private string connection { get; set; }
        public ScheduleCreator(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("DoctorConnection");
        }
        public bool CreateScheduleForDoctor(string doctorId, DateTime start, DateTime end)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connection))
                {
                    con.Open();
                    NpgsqlCommand command =
                        new NpgsqlCommand("Call fill_shift(" +
                        ":userid, :shiftstart, :shiftend)",con);
                    command.Parameters.AddWithValue("userid",NpgsqlDbType.Text, doctorId);
                    command.Parameters.AddWithValue("shiftstart",NpgsqlDbType.Timestamp, start);
                    command.Parameters.AddWithValue("shiftend",NpgsqlDbType.Timestamp, end);
                    var reader = command.ExecuteReader();

                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}
