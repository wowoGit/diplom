using System.Collections.Generic;
using testing.Models;
namespace testing.ViewModels
{
    public class HistoryVM
    {
        public HistoryVM()
        {
            HDocuments = new List<Historydocument>(); 
            HMedications = new List<Historymedication>(); 
            HProcedures = new List<Historyprocedure>(); 
        }
        public string Diagnosis { get; set; }
        public int appointmentId { get; set; }
        public List<Historydocument> HDocuments {get;set;}
        public List<Historymedication> HMedications {get;set;}
        public List<Historyprocedure> HProcedures {get;set;}
    }
}
