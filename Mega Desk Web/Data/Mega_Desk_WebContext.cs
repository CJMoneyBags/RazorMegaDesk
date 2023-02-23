using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorMegaDesk.Models;

namespace Mega_Desk_Web.Data
{
    public class Mega_Desk_WebContext : DbContext
    {
        public Mega_Desk_WebContext (DbContextOptions<Mega_Desk_WebContext> options)
            : base(options)
        {
        }

        public DbSet<RazorMegaDesk.Models.DeskQuote> DeskQuote { get; set; } = default!;
    }
}
