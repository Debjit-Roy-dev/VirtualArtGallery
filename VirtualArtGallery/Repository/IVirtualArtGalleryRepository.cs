using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Model;

namespace VirtualArtGallery.Repository
{
    internal interface IVirtualArtGalleryRepository
    {
        public bool addArtwork(Artwork artwork);
        public bool removeArtwork(int artworkId);
        public Artwork getArtworkById(int artworkId);
        public bool addArtworkToFavourite(int userId, int artWorkId);

        public bool removeArtworkToFavourite(int userId, int artWorkId);

        public bool updateArtwork(Artwork artwork,int artworkId);

        public List<Artwork> searchArtworksbyArtist(string artist);
        
        public List<Artwork> getUserFavouriteArtworks(int userId);
        public bool createGallery(Gallery gallery);
        public bool updateGallery(Gallery gallery, int galleryId);
        public bool removeGallery(int galleryId);
        public Gallery getGalleryById(int galleryId);
        public string verifyUser(string username,string password);

    }
}
