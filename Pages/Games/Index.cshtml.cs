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

namespace VladMedrisWebApp.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly VladMedrisWebApp.Data.VladMedrisWebAppContext _context;

        public IndexModel(VladMedrisWebApp.Data.VladMedrisWebAppContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }
        public GameData GameD { get; set; }
        public int GameID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            GameD = new GameData();

            GameD.Games = await _context.Game
                 .Include(b => b.PublishingCompany)
                 .Include(b => b.GameCategories)
                 .ThenInclude(b => b.Category)
                 .AsNoTracking()
                 .OrderBy(b => b.Title)
                 .ToListAsync();

            if (id != null)
            {
                GameID = id.Value;
                Game game = GameD.Games
                .Where(i => i.ID == id.Value).Single();
                GameD.Categories = game.GameCategories.Select(s => s.Category);
            }
        }
    }
}
