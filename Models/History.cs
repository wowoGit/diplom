using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class History
    {
        public History()
        {
            Historydocuments = new HashSet<Historydocument>();
            Historymedications = new HashSet<Historymedication>();
            Historyprocedures = new HashSet<Historyprocedure>();
        }

        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual ICollection<Historydocument> Historydocuments { get; set; }
        public virtual ICollection<Historymedication> Historymedications { get; set; }
        public virtual ICollection<Historyprocedure> Historyprocedures { get; set; }
    }
}
