#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VladMedrisWebApp.Data;
using VladMedrisWebApp.Models;

namespace VladMedrisWebApp.Pages.PublishingCompanies
{
    public class DeleteModel : PageModel
    {
        private readonly VladMedrisWebApp.Data.VladMedrisWebAppContext _context;

        public DeleteModel(VladMedrisWebApp.Data.VladMedrisWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PublishingCompany PublishingCompany { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PublishingCompany = await _context.PublishingCompany.FirstOrDefaultAsync(m => m.ID == id);

            if (PublishingCompany == null)
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

            PublishingCompany = await _context.PublishingCompany.FindAsync(id);

            if (PublishingCompany != null)
            {
                _context.PublishingCompany.Remove(PublishingCompany);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
