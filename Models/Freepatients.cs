using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public class Freepatients
    {
        [Column("p_id")]
        public string Pid { get; set; }
        [Column("p_fname")]
        public string Firstname { get; set; }
        [Column("p_lname")]
        public string Lastname { get; set; }
        [Column("p_patro")]
        public string Patronymic { get; set; }
        [Column("dateofbirth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
    }
}
