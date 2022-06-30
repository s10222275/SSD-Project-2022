﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSD_Project.Data;
using SSD_Project.Models;

namespace SSD_Project.Pages.Facilities
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
            return Page();
        }
        
        [BindProperty]
        public Models.Facility Facility { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Facility.Add(Facility);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
