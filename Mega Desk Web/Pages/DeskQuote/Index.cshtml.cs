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

        public string CustomerSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            // Searching by customer name.
            var quotes = from q in _context.DeskQuote
                         select q;
            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(q => q.CustomerName.Contains(SearchString));
            }

            // Sorting
            CustomerSort = String.IsNullOrWhiteSpace(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    quotes = quotes.OrderByDescending(s => s.CustomerName);
                    break;
                case "Date":
                    quotes = quotes.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    quotes = quotes.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    quotes = quotes.OrderBy(s => s.CustomerName);
                    break;
            }    

                DeskQuote = await quotes.ToListAsync();
            
        }
    }
}
