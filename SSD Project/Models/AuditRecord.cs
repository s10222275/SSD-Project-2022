using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Project.Models
{
    public class AuditRecord
    {
        public int AuditRecordID { get; set; }
        public string AuditActionType { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public string Username { get; set; }
    }
}
