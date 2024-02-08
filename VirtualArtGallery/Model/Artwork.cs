using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    public class Artwork
    {
        private int artworkId;
        private string title;
        private string description;
        private DateTime creationDate;
        private string medium;
        private string imageUrl;
        private int artistId;
        public Artwork() { }
        public Artwork(int artworkId, string title, string description, DateTime creationDate, string medium, string imageUrl, int artistId)
        {
            ArtworkId = artworkId;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Medium = medium;
            ImageUrl = imageUrl;
            ArtistId = artistId;
        }

        public int ArtworkId
        {
            get { return artworkId; } 
            set {  artworkId = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime CreationDate
        { 
            get { return creationDate; } 
            set {  creationDate = value; } 
        }
        public string Medium
        {
            get { return medium; }
            set { medium = value; }
        }
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }
        public int ArtistId
        {
            get { return artistId; }
            set { artistId = value; }
        }
    }
}
