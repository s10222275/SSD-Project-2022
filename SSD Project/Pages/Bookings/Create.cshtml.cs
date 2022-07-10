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
            if (Booking.StartTime > Booking.EndTime)
            {
                ModelState.AddModelError("EndTime", "End Time Earlier then Start Time, Please Re-enter again.");
            }
            foreach (Facility F in _context.Facility)
            {
                if (F.FacilityID == Booking.FacilityID)
                {
                    Booking.Facilitys = F;
                    System.Diagnostics.Debug.WriteLine("true");
                }

            }
            Slots slots = new Slots();
            slots.EndTime = Booking.EndTime;
            slots.StartTime = Booking.StartTime;
            if (slots.EndTime < slots.StartTime)
            {

                return Page();
            }
            System.Diagnostics.Debug.WriteLine(Booking.Facilitys.Name);
            foreach (Slots s in Booking.Facilitys.NotAvailableSlots)
            {
                if (s == slots)
                {
                    return Page();
                }
            }
            Booking.Facilitys.NotAvailableSlots.Add(slots);
            System.Diagnostics.Debug.WriteLine(Booking.Facilitys.NotAvailableSlots[0].ToString());

            _context.Booking.Add(Booking);
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Add New Booking";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.AuditRecordID = Booking.BookingID;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
