using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSD_Project.Data;
using SSD_Project.Models;

namespace SSD_Project.Pages.Facilities
{
    public class IndexModel : PageModel
    {
        private readonly SSD_Project.Data.SSD_ProjectContext _context;

        public IndexModel(SSD_Project.Data.SSD_ProjectContext context)
        {
            _context = context;
        }

        public IList<Models.Facility> Facility { get;set; }

        public async Task OnGetAsync()
        {
            Facility = await _context.Facility.ToListAsync();
        }
    }
}
