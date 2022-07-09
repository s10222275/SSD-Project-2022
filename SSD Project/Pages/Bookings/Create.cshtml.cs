using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSD_Project.Data;
using SSD_Project.Models;

namespace SSD_Project.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly SSD_Project.Data.SSD_ProjectContext _context;

        public CreateModel(SSD_Project.Data.SSD_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FacilityID"] = new SelectList(_context.Facility, "FacilityID", "Name");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Booking.Time = DateTime.Now;
            Booking.StatusOfBooking = "Pending";
            Booking.CheckInStatus = false;
           

            _context.Booking.Add(Booking);
            

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
