using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Project.Models
{
    public class Image
    {
        public string Path { get; set; }
        public int ImageID { get; set; }
        [NotMappedAttribute]
        public IFormFile File { get; set; }
    }
}
