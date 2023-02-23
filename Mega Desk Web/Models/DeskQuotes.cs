using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RazorMegaDesk.Models
{
    public class DeskQuote
    {
        public int Id { get; set; }

        [Display(Name = "Desk Material")]
        [Required]
        public string DeskMaterial { get; set; }

        //public Desk Desk { get; set; }

        [Display(Name = "Rush Option")]
        [Required]
        public int RushDays { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Total")]
        [DataType(DataType.Currency)]
        public double QuoteTotal { get; set; }

        [Range(24, 96)]
        [Required]

        public int Width { get; set; }
        [Range(12, 48)]
        [Required]

        public int Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        [Range(0, 7)]
        [Required]

        public int NumberOfDrawers { get; set; }

        public const int SQUAREINCHPRICE = 1;
        public const int DRAWERPRICE = 50;
        public List<DeskQuote> deskQuotes = new List<DeskQuote>();
    }
}