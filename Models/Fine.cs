using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class Fine
    {
        public Fine()
        {
            TotalPrices = new HashSet<TotalPrice>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? FineAmount { get; set; }

        public virtual ICollection<TotalPrice> TotalPrices { get; set; }
    }
}
