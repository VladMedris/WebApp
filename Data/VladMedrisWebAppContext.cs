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
    }
}
