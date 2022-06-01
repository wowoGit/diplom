using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace testing.Models
{
    public partial class Freeappointmentsweek
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public decimal? Price { get; set; }
        public int? Cabinet { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        [Column("id")]
        public int? Id { get; set; }
        [Column("schedule_id")]
        public int ScheduleId { get; set; }
    }
}
