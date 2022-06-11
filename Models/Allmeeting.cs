using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    [Keyless]
    [Table("allmeetings")]
    public class Allmeeting
    {
        [Column("diagnosis")]
        public string? Diagnosis { get; set; }
        [Column("info")]
        public string Info { get; set; }
        [Column("firstname")]
        public string Firstname { get; set; }
        [Column("lastname")]
        public string Lastname { get; set; }
        [Column("patronymic")]
        public string Patronymic { get; set; }
        [Column("doc_id")]
        public string DocId { get; set; }
        [Column("medcardid")]
        public string MedcardId { get; set; }
        [Column("appointmentid")]
        public int? AppointmentId { get; set; }
        [Column("depname")]
        public string Depname { get; set; }
        [Column("appdate")]
        public DateTime Appdate { get; set; }
    }
}
