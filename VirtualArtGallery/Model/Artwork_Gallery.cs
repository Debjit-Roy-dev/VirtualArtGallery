using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class Artwork_Gallery
    {
        private int artworkId;
        private int galleryId;

        public int ArtworkId
        {
            get { return artworkId; }
            set { artworkId = value; }
        }
        public int GalleryId
        {
            get { return galleryId; }
            set { galleryId = value; }
        }

        public Artwork_Gallery() { }
        public Artwork_Gallery(int artworkId, int galleryId)
        {
            ArtworkId = artworkId;
            GalleryId = galleryId;
            
        }
    }
}
