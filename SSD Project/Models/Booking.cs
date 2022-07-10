using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSD_Project.Models
{
    public class Booking
    {
        public int  BookingID { get; set; }
        public DateTime Time { get; set; }
        public int FacilityID { get; set; }
        public Facility Facilitys { get; set; }
        public string StatusOfBooking { get; set; }
        public bool CheckInStatus { get; set; }
   

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Range(0,999)]
        public int NumOfPeople { get; set; }


    }
}
