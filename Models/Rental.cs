using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class Rental
    {
        public Rental()
        {
            CarSharingPrices = new HashSet<CarSharingPrice>();
        }

        public int Id { get; set; }
        public int? IdClient { get; set; }
        public int? IdAuto { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }

        public virtual Auto? IdAutoNavigation { get; set; }
        public virtual Client? IdClientNavigation { get; set; }
        public virtual ICollection<CarSharingPrice> CarSharingPrices { get; set; }
    }
}
