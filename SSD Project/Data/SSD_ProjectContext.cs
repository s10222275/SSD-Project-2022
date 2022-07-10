using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSD_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace SSD_Project.Data
{
    public class SSD_ProjectContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SSD_ProjectContext (DbContextOptions<SSD_ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<SSD_Project.Models.Facility> Facility { get; set; }

        public DbSet<SSD_Project.Models.Booking> Booking { get; set; }
    }
}
