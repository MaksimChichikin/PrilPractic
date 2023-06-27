using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class Discount
    {
        public Discount()
        {
            CarSharingPrices = new HashSet<CarSharingPrice>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? PercentDiscount { get; set; }

        public virtual ICollection<CarSharingPrice> CarSharingPrices { get; set; }
    }
}
