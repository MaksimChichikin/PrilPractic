using System;
using System.Collections.Generic;

namespace PrilPractika.Models
{
    public partial class User
    {
        public User()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? IdRole { get; set; }

        public virtual Role? IdRoleNavigation { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
