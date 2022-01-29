#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VladMedrisWebApp.Data;
using VladMedrisWebApp.Models;

namespace VladMedrisWebApp.Pages.PublishingCompanies
{
    public class CreateModel : PageModel
    {
        private readonly VladMedrisWebApp.Data.VladMedrisWebAppContext _context;

        public CreateModel(VladMedrisWebApp.Data.VladMedrisWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PublishingCompany PublishingCompany { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PublishingCompany.Add(PublishingCompany);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
