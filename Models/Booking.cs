using System;
using System.Collections.Generic;

namespace interaction_bdd_crud.Models
{
    public partial class Booking
    {
        public ushort Id { get; set; }
        public DateTime BookedAt { get; set; }
        public ushort IdContact { get; set; }
        public ushort IdAlbum { get; set; }

        public virtual Album IdAlbumNavigation { get; set; } = null!;
        public virtual Contact IdContactNavigation { get; set; } = null!;
    }
}
