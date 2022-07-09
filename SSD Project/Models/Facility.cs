using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SSD_Project.Models
{
    public class Facility
    {
        public int FacilityID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        public int MaxNumOfPeople { get; set; }
        [Required]
        public string BlockNum { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string LevelNo { get; set; }
        [Required]
        public string RommNo { get; set; }
        [Required]
        public string Description { get; set; }
        public string FilePath { get; set; }
        public List<Slots> NotAvailableSlots = new List<Slots>();
      


    }
}
