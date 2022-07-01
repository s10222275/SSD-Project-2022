using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Project.Models
{
    public class Bookings
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public Facility Facility { get; set; }


    }
}
