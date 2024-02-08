using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    public class Gallery
    {
        private int galleryId;
        private string name;
        private string description;
        private string location;
        private int curator;
        private string openingHours;

        public int GalleryId
        {
            get { return galleryId; }
            set { galleryId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public int Curator
        {
            get { return curator; }
            set { curator = value; }
        }
        public string OpeningHours
        {
            get { return openingHours; }
            set { openingHours = value; }
        }
        public Gallery() { }
        public Gallery(int galleryId, string name, string description, string location, int curator, string openingHours)
        {
            GalleryId = galleryId;
            Name = name;
            Description = description;
            Location = location;
            Curator = curator;
            OpeningHours = openingHours;
            
        }
    }
}
