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

namespace VladMedrisWebApp.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly VladMedrisWebApp.Data.VladMedrisWebAppContext _context;

        public DetailsModel(VladMedrisWebApp.Data.VladMedrisWebAppContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
