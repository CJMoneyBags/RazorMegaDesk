using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mega_Desk_Web.Data;
using RazorMegaDesk.Models;

namespace Mega_Desk_Web.Pages.DeskQuote
{
    public class EditModel : PageModel
    {
        private readonly Mega_Desk_Web.Data.Mega_Desk_WebContext _context;

        public EditModel(Mega_Desk_Web.Data.Mega_Desk_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RazorMegaDesk.Models.DeskQuote DeskQuote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }

            var deskquote =  await _context.DeskQuote.FirstOrDefaultAsync(m => m.Id == id);
            if (deskquote == null)
            {
                return NotFound();
            }
            DeskQuote = deskquote;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int price = 200;
            int area = (DeskQuote.Width * DeskQuote.Depth);
            if (area > 1000)
            {
                price += area;
            }

            price += DeskQuote.NumberOfDrawers;
            if (DeskQuote.DeskMaterial == "Oak")
            {
                price += 200;
            }
            else if (DeskQuote.DeskMaterial == "Laminate")
            {
                price += 100;
            }
            else if (DeskQuote.DeskMaterial == "Pine")
            {
                price += 50;
            }
            else if (DeskQuote.DeskMaterial == "Rosewood")
            {
                price += 300;
            }
            else
            {
                // Veneer
                price += 125;
            }
            if (area < 1000)
            {
                if (DeskQuote.RushDays == 3)
                {
                    price += 60;
                }
                else if (DeskQuote.RushDays == 5)
                {
                    price += 40;
                }
                else
                {
                    price += 30;

                }

            }
            else if (area >= 1000 && area < 2000)
            {
                if (DeskQuote.RushDays == 3)
                {
                    price += 70;
                }
                else if (DeskQuote.RushDays == 5)
                {
                    price += 50;
                }
                else
                {
                    price += 35;

                }
            }
            else
            {
                // > 2000
                if (DeskQuote.RushDays == 3)
                {
                    price += 80;
                }
                else if (DeskQuote.RushDays == 5)
                {
                    price += 60;
                }
                else
                {
                    price += 40;

                }
            }

            DeskQuote.QuoteTotal = price;


            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
          return (_context.DeskQuote?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
