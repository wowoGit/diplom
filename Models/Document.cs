using System;
using System.Collections.Generic;

#nullable disable

namespace testing.Models
{
    public partial class Document
    {
        public Document()
        {
            Historydocuments = new HashSet<Historydocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Historydocument> Historydocuments { get; set; }
    }
}
