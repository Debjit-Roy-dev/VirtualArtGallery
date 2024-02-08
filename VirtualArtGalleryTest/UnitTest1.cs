using VirtualArtGallery;
using VirtualArtGallery.Service;
using VirtualArtGallery.Repository;
using VirtualArtGallery.Exception;
using VirtualArtGallery.Model;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;

namespace VirtualArtGalleryTest
{
    public class Tests
    {
        VirtualArtGalleryRepositoryImpl _virtualArtGalleryService;


        [SetUp]
        public void Setup()
        {
            _virtualArtGalleryService=new VirtualArtGalleryRepositoryImpl();
        }
        /*
                [Test]
                 public void ifNewArtworkAdded()
                 {
                     Artwork testArtwork=new Artwork
                     {
                     ArtworkId = 1007,
                     Title = "The Old Guiterist",
                     Description = "A Blue period Masterpiece reflects picasso's emotional and somber exploration of poverty.",
                     CreationDate = new DateTime(1904,3,15),
                     Medium = "Oil Painting",
                     ImageUrl = "D/Image7",
                     ArtistId = 1
                     };
                     bool addArtworkStatus = _virtualArtGalleryService.addArtwork(testArtwork);
                     Assert.IsTrue(addArtworkStatus);

                 }

                [Test]

                public void ifNewArtworkUpdated()
                {
                    Artwork testArtwork = new Artwork
                    {
                        ArtworkId = 1007,
                        Title = "The Old Guiterist",
                        Description = "A Blue period Masterpiece reflects picasso's emotional and somber exploration of overty.",
                        CreationDate = new DateTime(1903, 12, 19),
                        Medium = "Oil Painting on Canvas",
                        ImageUrl = "D/Artworks/Image7",
                        ArtistId = 1
                    };
                    int artworkId = 1007;
                    bool updateArtworkStaus = _virtualArtGalleryService.updateArtwork(testArtwork, artworkId);
                    Assert.IsTrue(updateArtworkStaus);
                }
                [Test]
                public void updateArtworkException()
                {
                    Artwork testArtwork = new Artwork
                    {
                        ArtworkId = 1007,
                        Title = "The Old Guiterist",
                        Description = "A Blue period Masterpiece reflects picasso's emotional and somber exploration of overty.",
                        CreationDate = new DateTime(1903, 12, 19),
                        Medium = "Oil Painting on Canvas",
                        ImageUrl = "D/Artworks/Image7",
                        ArtistId = 1
                    };

                    int nonExistingArtworkId = 1;
                    Assert.Throws<ArtWorkNotFoundException>(() => _virtualArtGalleryService.updateArtwork(testArtwork,nonExistingArtworkId));


                }
                [Test]

                public void ifArtworkDeleted()
                {
                    int artworkId = 1007;
                    bool removeArtworkStatus = _virtualArtGalleryService.removeArtwork(artworkId);
                    Assert.IsTrue( removeArtworkStatus);
                }

                [Test]
                public void removeArtworkException()
                {

                    int nonExistingArtworkId = 1;
                    Assert.Throws<ArtWorkNotFoundException>(() => _virtualArtGalleryService.removeArtwork(nonExistingArtworkId));

                }
                [Test]
                public void getArtworkbyId()
                {
                    ArtworkId = 1007;
                    
                    int artworkIdToSearch = 1007;
                    Artwork artworkById = _virtualArtGalleryService.getArtworkById(artworkIdToSearch);
                    Assert.AreEqual(ArtworkId, artworkById.ArtworkId);
                }
                [Test]
                public void getArtworkbyIdException()
                {
                    int nonExistingArtworkId = 1;
                    Assert.Throws<ArtWorkNotFoundException>(() => _virtualArtGalleryService.getArtworkById(nonExistingArtworkId));
                }*/
        /* [Test]
         public void ifGalleryCreated()
         {
             Gallery gallery = new Gallery
             {
                 GalleryId = 105,
                 Name = "The Royal Gallery",
                 Description = "An Art Gallery of Royal Ambience.",
                 Location = "Kolkata",
                 Curator = 3,
                 OpeningHours = "9 A.M. to 6 P.M."
             };
             bool addGalleryStatus = _virtualArtGalleryService.createGallery(gallery);
             Assert.IsTrue(addGalleryStatus);
         }
         [Test]
         public void ifGalleryUpdated()
         {
             int updateid = 105;
             Gallery gallery = new Gallery
             {
                 GalleryId = 105,
                 Name = "The Royal Arena Gallery",
                 Description = "An Art Gallery of Royal Ambience.",
                 Location = "Kolkata",
                 Curator = 3,
                 OpeningHours = "9 A.M. to 7 P.M."
             };
             bool updateGalleryStatus = _virtualArtGalleryService.updateGallery(gallery,updateid);
             Assert.IsTrue(updateGalleryStatus);
         }
         */
        [Test]
        public void GalleryUpdateException()
        {
            int nonexistingUpdateid = 1005;
            Gallery gallery = new Gallery
            {
                GalleryId = 1005,
                Name = "The Royal Arena Gallery",
                Description = "An Art Gallery of Royal Ambience.",
                Location = "Kolkata",
                Curator = 3,
                OpeningHours = "9 A.M. to 7 P.M."
            };
            
            Assert.Throws<GalleryNotFoundException>(()=>_virtualArtGalleryService.updateGallery(gallery, nonexistingUpdateid));
        }

       /* [Test]
        public void ifRemoveGallery()
        {
            int galleryId = 105;
            Assert.IsTrue(_virtualArtGalleryService.removeGallery(galleryId));

        }*/
        [Test]
        public void RemoveGalleryException()
        {
            int nonexistantId= 1256;
            Assert.Throws<GalleryNotFoundException>(() => _virtualArtGalleryService.removeGallery(nonexistantId));

        }
        [Test]
        public void GetGalleryByIdTest()
        {
            int galleryId = 103;
            Gallery gallery = _virtualArtGalleryService.getGalleryById(galleryId);
            Assert.AreEqual(galleryId,gallery.GalleryId);
        }

        [Test] public void GetGalleryByIdException()
        {
            int nonexistingGalleryId = 10002;
            Assert.Throws<GalleryNotFoundException>(() => _virtualArtGalleryService.getGalleryById(nonexistingGalleryId));
        }

    }

}