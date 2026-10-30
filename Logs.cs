using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMARTCHART
{
    public class Logs
    {// constructors, getters and setters for the Logs class.
        public string UserName { get; set; }
        public string Action { get; set; }
        public string PatientID { get; set; }
        public DateTime Timestamp { get; set; }
        public Logs(string userName, string action, string patientID)
        {
            UserName = userName;
            Action = action;
            PatientID = patientID;
            Timestamp = DateTime.Now;
        }
    }
}
