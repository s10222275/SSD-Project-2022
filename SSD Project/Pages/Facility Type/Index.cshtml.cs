using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSD_Project.Data;
using SSD_Project.Models;

namespace SSD_Project.Pages.Facility_Types
{
    public class IndexModel : PageModel
    {
        private readonly SSD_Project.Data.SSD_ProjectContext _context;

        public IndexModel(SSD_Project.Data.SSD_ProjectContext context)
        {
            _context = context;
        }

        public IList<FacilityType> FacilityType { get;set; }

        public async Task OnGetAsync()
        {
            FacilityType = await _context.FacilityType.ToListAsync();
        }
    }
}
