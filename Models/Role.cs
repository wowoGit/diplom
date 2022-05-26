using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
