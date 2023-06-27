using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class TotalPrice
    {
        public int Id { get; set; }
        public int? IdCarSharingPrice { get; set; }
        public int? IdFine { get; set; }
        public decimal? Price { get; set; }

        public virtual CarSharingPrice? IdCarSharingPriceNavigation { get; set; }
        public virtual Fine? IdFineNavigation { get; set; }
    }
}
