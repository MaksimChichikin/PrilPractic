using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class Client
    {
        public Client()
        {
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PassportData { get; set; }
        public string? DrivingLicenseData { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
