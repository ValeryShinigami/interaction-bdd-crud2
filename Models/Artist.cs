using System;
using System.Collections.Generic;

namespace interaction_bdd_crud.Models
{
    public partial class Artist
    {
        public Artist()
        {
            AlbumArtists = new HashSet<AlbumArtist>();
        }

        public ushort Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Birthday { get; set; }

        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; }
    }
}
