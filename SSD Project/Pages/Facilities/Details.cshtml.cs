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
    public class DetailsModel : PageModel
    {
        private readonly SSD_Project.Data.SSD_ProjectContext _context;

        public DetailsModel(SSD_Project.Data.SSD_ProjectContext context)
        {
            _context = context;
        }

        public Facility Facility { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Facility = await _context.Facility.FirstOrDefaultAsync(m => m.FacilityID == id);

            if (Facility == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
