using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Medication
    {
        public Medication()
        {
            Historymedications = new HashSet<Historymedication>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Historymedication> Historymedications { get; set; }
    }
}
