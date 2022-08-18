using System;
using System.Collections.Generic;

namespace interaction_bdd_crud.Models
{
    public partial class AlbumArtist
    {
        public ushort Id { get; set; }
        public ushort IdAlbum { get; set; }
        public ushort IdArtist { get; set; }

        public virtual Album IdAlbumNavigation { get; set; } = null!;
        public virtual Artist IdArtistNavigation { get; set; } = null!;
    }
}
