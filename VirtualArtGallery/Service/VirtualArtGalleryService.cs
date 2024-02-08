using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Repository;
using VirtualArtGallery.Model;
using VirtualArtGallery.Exception;

namespace VirtualArtGallery.Service
{
    internal class VirtualArtGalleryService : IVirtualArtGalleryService
    {
        readonly IVirtualArtGalleryRepository _virtualArtGalleryRepository;
        public VirtualArtGalleryService()
        {
            _virtualArtGalleryRepository = new VirtualArtGalleryRepositoryImpl();

        }
        public void AddArtwork()
        {
            Console.WriteLine("Enter ArtworkId:");
            int artworkId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Creation Date");
            DateTime creationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Medium:");
            string medium = Console.ReadLine();
            Console.WriteLine("Enter ImageUrl");
            string imageUrl = Console.ReadLine();
            Console.WriteLine("Enter Artist Id:");
            int artistId = Convert.ToInt32(Console.ReadLine());

            Artwork artwork = new Artwork(artworkId, title, description, creationDate, medium, imageUrl, artistId);

            bool addArtworkStatus = _virtualArtGalleryRepository.addArtwork(artwork);
            if (addArtworkStatus) { Console.WriteLine("Artwork Added Successfully."); }
            else { Console.WriteLine("Couldn't Add Artwork."); }

        }
        public void RemoveArtwork()
        {
            try
            {
                Console.WriteLine("Enter ArtworkId to Remove :");
                int artworkId = Convert.ToInt32(Console.ReadLine());
                bool artworkRemoveStatus = _virtualArtGalleryRepository.removeArtwork(artworkId);
                
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void GetArtworkById()
        {
            try
            {
                Console.WriteLine("Enter Artwork Id to Find:");
                int artworkId = Convert.ToInt32(Console.ReadLine());
                Artwork artwork = _virtualArtGalleryRepository.getArtworkById(artworkId);
                if (artwork != null)
                {
                    Console.WriteLine($"Artwork Id:{artwork.ArtworkId}\nTitle:{artwork.Title}\nDescription:{artwork.Description}\nCreation Date:{artwork.CreationDate}\nMedium:{artwork.Medium}\nImageUrl:{artwork.ImageUrl}\nArtist Id:{artwork.ArtistId}.");

                }
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void AddArtworkToFavourite()
        {
            try
            {
                Console.WriteLine("Enter User Id to add:");
                int userId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Artwork Id to add:");
                int artworkId = Convert.ToInt32(Console.ReadLine());
                bool adduserfavartworkStatus = _virtualArtGalleryRepository.addArtworkToFavourite(userId, artworkId);
                if (adduserfavartworkStatus) { Console.WriteLine("Artwork Successfully added to Favourite."); }
                else { Console.WriteLine("Couldn't Add Artwork to Favourite."); }
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void RemoveArtworkToFavourite()
        {
            try
            {
                Console.WriteLine("Enter User Id to remove:");
                int userId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Artwork Id to remove:");
                int artworkId = Convert.ToInt32(Console.ReadLine());
                bool adduserfavartworkStatus = _virtualArtGalleryRepository.removeArtworkToFavourite(userId, artworkId);
                if (adduserfavartworkStatus) { Console.WriteLine("Artwork Successfully removed from Favourites."); }
                else { Console.WriteLine("Couldn't remove Artwork from Favourites."); }

            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void UpdateArtwork()
        {
            try
            {
                Console.WriteLine("Enter ArtworkId of Artwork You want to Update :");
                int artworkId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new Title:");
                string title = Console.ReadLine();
                Console.WriteLine("Enter new Description:");
                string description = Console.ReadLine();
                Console.WriteLine("Enter new Creation Date");
                DateTime creationDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Medium:");
                string medium = Console.ReadLine();
                Console.WriteLine("Enter new ImageUrl");
                string imageUrl = Console.ReadLine();
                Console.WriteLine("Enter new Artist Id:");
                int artistId = Convert.ToInt32(Console.ReadLine());

                Artwork artwork = new Artwork(artworkId, title, description, creationDate, medium, imageUrl, artistId);

                bool updateArtworkStatus = _virtualArtGalleryRepository.updateArtwork(artwork, artworkId);
                if (updateArtworkStatus) { Console.WriteLine("Artwork Updated Successfully."); }
                else { Console.WriteLine("Couldn't Update Artwork."); }
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void SearchArtworksByArtist()
        {
            try
            {
                Console.WriteLine("Enter Artist name to search artworks of:");
                string artist = Console.ReadLine();
                List<Artwork> artworks = _virtualArtGalleryRepository.searchArtworksbyArtist(artist);

                if (artworks != null)
                {
                    foreach (Artwork artwork in artworks)
                    {
                        Console.WriteLine($"Artwork Id:{artwork.ArtworkId}\nTitle:{artwork.Title}\nDescription:{artwork.Description}\nCreation Date:{artwork.CreationDate}\nMedium:{artwork.Medium}\nImageUrl:{artwork.ImageUrl}\nArtist Id:{artwork.ArtistId}\n");

                    }
                }
                else { Console.WriteLine("No Artwork by Such Artist Found."); }
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void GetUserFavouriteArtworks()
        {

            try
            {
                Console.WriteLine("Enter User Id to get favourite artworks:");
                int userId = Convert.ToInt32(Console.ReadLine());
                List<Artwork> artworks = _virtualArtGalleryRepository.getUserFavouriteArtworks(userId);
                if (artworks != null)
                {
                    foreach (Artwork artwork in artworks)
                    {
                        Console.WriteLine($"Artwork Id:{artwork.ArtworkId}\nTitle:{artwork.Title}\nDescription:{artwork.Description}\nCreation Date:{artwork.CreationDate}\nMedium:{artwork.Medium}\nImageUrl:{artwork.ImageUrl}\nArtist Id:{artwork.ArtistId}\n");
                    }
                }
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        public void AddGallery()
        {
            try
            {
                Gallery gallery = new Gallery();
                Console.WriteLine("Enter gallery Id:");
                gallery.GalleryId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter gallery Name:");
                gallery.Name = Console.ReadLine();
                Console.WriteLine("Enter Description:");
                gallery.Description = Console.ReadLine();
                Console.WriteLine("Enter Location:");
                gallery.Location = Console.ReadLine();
                Console.WriteLine("Enter Curator:");
                gallery.Curator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter Opening Hours:");
                gallery.OpeningHours = Console.ReadLine();

                bool addGalleryStatus = _virtualArtGalleryRepository.createGallery(gallery);
                if (addGalleryStatus)
                {
                    Console.WriteLine("Gallery Successfully Added.");
                }
                else
                {
                    Console.WriteLine("Can not add Gallery.");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An Error Occured{ex.Message}");
            }
        }

        public void UpdateGallery()
        {
            try
            {
                Gallery gallery = new Gallery();
                Console.WriteLine("Enter gallery Id:");
                gallery.GalleryId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter gallery Name:");
                gallery.Name = Console.ReadLine();
                Console.WriteLine("Enter Description:");
                gallery.Description = Console.ReadLine();
                Console.WriteLine("Enter Location:");
                gallery.Location = Console.ReadLine();
                Console.WriteLine("Enter Curator:");
                gallery.Curator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter Opening Hours:");
                gallery.OpeningHours = Console.ReadLine();

                bool updateGalleryStatus = _virtualArtGalleryRepository.updateGallery(gallery, gallery.GalleryId);
                if (updateGalleryStatus)
                {
                    Console.WriteLine("Gallery Successfully updated.");
                }
                else
                {
                    Console.WriteLine("Can not update Gallery.");
                }
            }
            catch (GalleryNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void RemoveGallery()
        {
            try
            {
                Console.WriteLine("Enter GalleryId to Remove :");
                int galleryId = Convert.ToInt32(Console.ReadLine());
                bool galleryRemoveStatus = _virtualArtGalleryRepository.removeArtwork(galleryId);
                if (galleryRemoveStatus)
                {
                    Console.WriteLine("Gallery Removed.");
                }
            }
            catch (GalleryNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void GetGalleryById()
        {
            try
            {
                Console.WriteLine("Enter GalleryId to Search :");
                int galleryId = Convert.ToInt32(Console.ReadLine());
                Gallery gallery = _virtualArtGalleryRepository.getGalleryById(galleryId);
                if (gallery != null)
                {
                    Console.WriteLine($"Gallery Name:{gallery.Name}\nGallery Description:{gallery.Description}" +
                        $"Location:{gallery.Location}\nOpening Hours:{gallery.OpeningHours}");
                }
            }
            catch (GalleryNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public string VerifyUser()
        {
            int count = 3;
            string usertype = "";
            while (count >0 )
            {
                Console.WriteLine("Enter UserName:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string password = Console.ReadLine();
                count--;
                usertype = _virtualArtGalleryRepository.verifyUser(username, password);
                if (usertype!="unknown")
                {
                    Console.WriteLine($"Welcome {username}.");
                    return usertype;
                }
                else
                {
                    Console.WriteLine($"Try Again.{count} more try left.");
                }
                
            }
            Console.WriteLine("Could not Login .");
            return usertype;
        }
    }
}


