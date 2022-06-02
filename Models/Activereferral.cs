using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    [Table(name:"activereferrals")]
    public class Activereferral
    {
        [Column("declaration_id")]
        public string DeclarationId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("issued_date")]
        [DataType(DataType.Date)]
        public DateTime IssuedDate { get; set; }
    }
}
