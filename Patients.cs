using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMARTCHART
{
    internal class Patients
    {// initializing the properties of the patient class with default values
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public bool Insured { get; set; } = false;
        public DateTime DateOfBirth { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
