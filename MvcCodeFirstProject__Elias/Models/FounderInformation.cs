using System;
using System.Collections.Generic;

namespace MvcCodeFirstProject__Elias.Models
{
    
    public partial class FounderInformation
    {
        
        public int FounderInformationID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
