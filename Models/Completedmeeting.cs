using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Completedmeeting
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Patronymic { get; set; }
        public string Diag { get; set; }
        public string Doc { get; set; }
        public DateTime? Dateo { get; set; }
        public DateTime? Datec { get; set; }
        public DateTime App_date { get; set; }
        public string App_info { get; set; }
        public string D_fname { get; set; }
        public string D_lname { get; set; }
        public string D_patro { get; set; }
        public string Pname { get; set; }
        public string Proc_result { get; set; }
        public DateTime? Dateop { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
    }
}
