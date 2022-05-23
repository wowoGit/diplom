using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Procedure
    {
        public Procedure()
        {
            Historyprocedures = new HashSet<Historyprocedure>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Historyprocedure> Historyprocedures { get; set; }
    }
}
