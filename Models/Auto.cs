using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class Auto
    {
        public Auto()
        {
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string? CarStateNumber { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public int? CarYear { get; set; }
        public decimal? InsuranceValue { get; set; }
        public decimal? PricePerMinute { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
