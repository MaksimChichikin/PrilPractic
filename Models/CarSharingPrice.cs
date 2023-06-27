using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class CarSharingPrice
    {
        public CarSharingPrice()
        {
            TotalPrices = new HashSet<TotalPrice>();
        }

        public int Id { get; set; }
        public int? IdRental { get; set; }
        public int? IdDiscount { get; set; }

        public virtual Discount? IdDiscountNavigation { get; set; }
        public virtual Rental? IdRentalNavigation { get; set; }
        public virtual ICollection<TotalPrice> TotalPrices { get; set; }
    }
}
