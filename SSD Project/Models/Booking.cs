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
        public virtual Facility Facilitys { get; set; }
        public string StatusOfBooking { get; set; }
        public bool CheckInStatus { get; set; }
   
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        [Range(0,999)]
        public int NumOfPeople { get; set; }


    }
    
}
