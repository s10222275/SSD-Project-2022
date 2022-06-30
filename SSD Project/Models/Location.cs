using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Project.Models
{
    public class Location
    {
        public int ID { get; set; }
        public int BlockNum { get; set; }
        public int LevelNo { get; set; }
        public int RoomNo { get; set; }
        public string LocationName { get; set; }

    }
}
