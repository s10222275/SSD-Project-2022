using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSD_Project.Data;
using SSD_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
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
        public Facility Facility { get; set; }

        public IFormFile Upload { get; set; }



        private string fullPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "wwwroot\\images";
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            {
                if (!ModelState.IsValid)
                    if (!ModelState.IsValid)
                    {
                        {
                            return Page();

                        }
                    }
                if (Upload == null)
                {
                    return Page();
                }
                // If directory does not exist, this file path will be created
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }

                var formFile = Upload;// Save variable
                var FileType = Upload.ContentDisposition;//get tag




                //If form file contains something
                if (formFile.Length > 0)
                {
                    //File Path for item
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", formFile.FileName);

                    System.Diagnostics.Debug.WriteLine(filePath.ToString());
                    Facility.FilePath = "/images" + "/" + formFile.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
                _context.Facility.Add(Facility);
                _context.Facility.Add(Facility);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
}
