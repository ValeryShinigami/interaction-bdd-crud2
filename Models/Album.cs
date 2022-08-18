using System;
using System.Collections.Generic;

namespace interaction_bdd_crud.Models
{
    public partial class Album
    {
        public Album()
        {
            AlbumArtists = new HashSet<AlbumArtist>();
        }

        public ushort Id { get; set; }
        public string Title { get; set; } = null!;
        public short CreatedYear { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; }
    }
}
