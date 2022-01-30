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

namespace VladMedrisWebApp.Pages.Games
{
    public class CreateModel : GameCategoriesPageModel
    {
        private readonly VladMedrisWebApp.Data.VladMedrisWebAppContext _context;

        public CreateModel(VladMedrisWebApp.Data.VladMedrisWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<PublishingCompany>(), "ID", "CompanyName");
            ViewData["PlatformID"] = new SelectList(_context.Set<Platform>(), "ID", "PlatformName");

            var game = new Game();
            game.GameCategories = new List<GameCategory>();
            PopulateAssignedCategoryData(_context, game);

            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newGame = new Game();
            if (selectedCategories != null)
            {
                newGame.GameCategories = new List<GameCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new GameCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newGame.GameCategories.Add(catToAdd);
                }

            }

            if (await TryUpdateModelAsync<Game>(
                 newGame, "Game",
                 i => i.Title, i => i.Studio,
                 i => i.Price, i => i.ReleaseDate, 
                 i => i.PlatformID,
                 i => i.PublisherID))
            {
                _context.Game.Add(newGame);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newGame);
            return Page();
        }
    }
   
}
