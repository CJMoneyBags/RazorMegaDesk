using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mega_Desk_Web.Data;
using RazorMegaDesk.Models;

namespace Mega_Desk_Web.Pages.DeskQuote
{
    public class IndexModel : PageModel
    {
        private readonly Mega_Desk_Web.Data.Mega_Desk_WebContext _context;

        public IndexModel(Mega_Desk_Web.Data.Mega_Desk_WebContext context)
        {
            _context = context;
        }

        public IList<RazorMegaDesk.Models.DeskQuote> DeskQuote { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DeskQuote != null)
            {
                DeskQuote = await _context.DeskQuote.ToListAsync();
            }
        }
    }
}
