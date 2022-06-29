using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSD_Project.Models;

namespace SSD_Project.Data
{
    public class SSD_ProjectContext : DbContext
    {
        public SSD_ProjectContext (DbContextOptions<SSD_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SSD_Project.Models.Location> Location { get; set; }
    }
}
