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
    public class DetailsModel : PageModel
    {
        private readonly SSD_Project.Data.SSD_ProjectContext _context;

        public DetailsModel(SSD_Project.Data.SSD_ProjectContext context)
        {
            _context = context;
        }

        public FacilityType FacilityType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FacilityType = await _context.FacilityType.FirstOrDefaultAsync(m => m.ID == id);

            if (FacilityType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
