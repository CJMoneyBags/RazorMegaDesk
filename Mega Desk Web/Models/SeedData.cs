using Mega_Desk_Web.Data;
using Microsoft.EntityFrameworkCore;
using RazorMegaDesk.Models;

namespace Mega_Desk_Web.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Mega_Desk_WebContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Mega_Desk_WebContext>>()))
            {
                if (context == null || context.DeskQuote == null)
                {
                    throw new ArgumentNullException("Null RazorPagesDeskQuoteContext");
                }

                // Look for any desk quotes
                if (context.DeskQuote.Any())
                {
                    return;   // DB has been seeded
                }

                context.DeskQuote.AddRange(
                    new DeskQuote
                    {
                        Id = 1,
                        DeskMaterial = "Oak",
                        RushDays = 14,
                        CustomerName = "Michael Scott",
                        QuoteDate = new DateTime(2023,01,01),
                        QuoteTotal = 1000,
                        Width = 96,
                        Depth = 48,
                        NumberOfDrawers = 5
                    },

                    new DeskQuote
                    {
                        Id = 2,
                        DeskMaterial = "Pine",
                        RushDays = 7,
                        CustomerName = "Dwight Schrute",
                        QuoteDate = new DateTime(2023, 01, 02),
                        QuoteTotal = 1500,
                        Width = 76,
                        Depth = 38,
                        NumberOfDrawers = 4
                    },

                    new DeskQuote
                    {
                        Id = 3,
                        DeskMaterial = "Veneer",
                        RushDays = 5,
                        CustomerName = "James Halpert",
                        QuoteDate = new DateTime(2023, 01, 03),
                        QuoteTotal = 1800,
                        Width = 96,
                        Depth = 48,
                        NumberOfDrawers = 6
                    },

                    new DeskQuote
                    {
                        Id = 4,
                        DeskMaterial = "Oak",
                        RushDays = 7,
                        CustomerName = "Chris Bagwell",
                        QuoteDate = new DateTime(2023, 02, 20),
                        QuoteTotal = 850,
                        Width = 96,
                        Depth = 48,
                        NumberOfDrawers = 3
                    },

                    new DeskQuote
                    {
                        Id = 5,
                        DeskMaterial = "Rosewood",
                        RushDays = 3,
                        CustomerName = "Austin Earl",
                        QuoteDate = new DateTime(2023, 02, 21),
                        QuoteTotal = 950,
                        Width = 45,
                        Depth = 45,
                        NumberOfDrawers = 4
                    },

                    new DeskQuote
                    {
                        Id = 6,
                        DeskMaterial = "Laminate",
                        RushDays = 14,
                        CustomerName = "Jason Macdonald",
                        QuoteDate = new DateTime(2023, 02, 22),
                        QuoteTotal = 780,
                        Width = 56,
                        Depth = 32,
                        NumberOfDrawers = 3
                    },

                    new DeskQuote
                    {
                        Id = 7,
                        DeskMaterial = "Oak",
                        RushDays = 5,
                        CustomerName = "Alex Vasiuk",
                        QuoteDate = new DateTime(2023, 02, 23),
                        QuoteTotal = 976,
                        Width = 70,
                        Depth = 35,
                        NumberOfDrawers = 5
                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}
