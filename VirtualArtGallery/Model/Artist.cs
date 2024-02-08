using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class Artist
    {
        private int artistId;
        private string name;
        private string biography;
        private DateTime birthdate;
        private string nationality;
        private string website;
        private long contactInformation;

        
        public int ArtistId
        {
            get { return artistId; }
            set { artistId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        public string Nationality
        {
                get { return nationality; }
                set { nationality = value; }
        }
        public string Website
        {
            get { return website; } 
            set { website = value; }
        }
        public long ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }

        public Artist() { }

        public Artist(int artistId, string name, string biography, DateTime birthdate, string nationality, string website, long contactInformation)
        {
            ArtistId = artistId;
            Name = name;
            Biography = biography;
            Birthdate = birthdate;
            Nationality = nationality;
            Website = website;
            ContactInformation = contactInformation;
        }

    }
}
