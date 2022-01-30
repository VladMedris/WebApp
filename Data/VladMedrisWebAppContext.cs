#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VladMedrisWebApp.Models;

namespace VladMedrisWebApp.Data
{
    public class VladMedrisWebAppContext : DbContext
    {
        public VladMedrisWebAppContext (DbContextOptions<VladMedrisWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<VladMedrisWebApp.Models.Game> Game { get; set; }

        public DbSet<VladMedrisWebApp.Models.PublishingCompany> PublishingCompany { get; set; }

        public DbSet<VladMedrisWebApp.Models.Category> Category { get; set; }

        public DbSet<VladMedrisWebApp.Models.GameCategory> GameCategory { get; set; }

        public DbSet<VladMedrisWebApp.Models.Platform> Platform { get; set; }
    }
}
