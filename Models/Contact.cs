using System;
using System.Collections.Generic;

namespace interaction_bdd_crud.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Bookings = new HashSet<Booking>();
        }

        public ushort Id { get; set; }
        public string Mail { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
