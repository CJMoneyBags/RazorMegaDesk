﻿using System;
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
