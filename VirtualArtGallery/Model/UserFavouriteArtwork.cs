using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class UserFavouriteArtwork
    {
        private int userId;
        private int artworkId;

        public int ArtworkId
        {
            get { return userId; }
            set { userId = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public UserFavouriteArtwork() { }
        public UserFavouriteArtwork(int userId, int artworkId)
        {
            UserId = userId;
            ArtworkId = artworkId;
            
        }
    }
}
