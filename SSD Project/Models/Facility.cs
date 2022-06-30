using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Project.Models
{
    public class Facility
    {
        public int ID { get; set; }
        public Location Venue { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int NumOfPeople { get; set; }
        public FacilityType Type { get; set; }
        
        
        
    }
}
