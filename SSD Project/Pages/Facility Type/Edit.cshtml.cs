using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSD_Project.Data;
using SSD_Project.Models;

namespace SSD_Project.Pages.Facility_Types
{
    public class EditModel : PageModel
    {
        private readonly SSD_Project.Data.SSD_ProjectContext _context;

        public EditModel(SSD_Project.Data.SSD_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FacilityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityTypeExists(FacilityType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FacilityTypeExists(int id)
        {
            return _context.FacilityType.Any(e => e.ID == id);
        }
    }
}
