using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSD_Project.Data;
using SSD_Project.Models;

namespace SSD_Project.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly SSD_Project.Data.SSD_ProjectContext _context;

        public DeleteModel(SSD_Project.Data.SSD_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bookings Bookings { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bookings = await _context.Bookings.FirstOrDefaultAsync(m => m.ID == id);

            if (Bookings == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bookings = await _context.Bookings.FindAsync(id);

            if (Bookings != null)
            {
                _context.Bookings.Remove(Bookings);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
