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

namespace VladMedrisWebApp.Pages.GameCategories
{
    public class DeleteModel : PageModel
    {
        private readonly VladMedrisWebApp.Data.VladMedrisWebAppContext _context;

        public DeleteModel(VladMedrisWebApp.Data.VladMedrisWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GameCategory GameCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameCategory = await _context.GameCategory
                .Include(g => g.Category)
                .Include(g => g.Game).FirstOrDefaultAsync(m => m.ID == id);

            if (GameCategory == null)
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

            GameCategory = await _context.GameCategory.FindAsync(id);

            if (GameCategory != null)
            {
                _context.GameCategory.Remove(GameCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
