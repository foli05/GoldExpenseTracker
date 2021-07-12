using System;
using System.Collections.Generic;
using System.Text;

namespace GoldExpenseTracker.Models
{
    public class Expense
    {
        public string Text { get; set; }

        public DateTime Date { get; set; }
        public DateTime PurchaseDate { get; set; }
        
        public Double Amount { get; set; }

        public string Category { get; set; }

        public string FileName { get; set; }

    }
}
