using VirtualArtGallery.Service;
namespace VirtualArtGallery
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IVirtualArtGalleryService v = new VirtualArtGalleryService();
            string usertype = v.VerifyUser();
            if (usertype == "unknown") return;

            if (usertype == "user") 
            {
                while (true)
                {
                    Console.WriteLine("Choose which Operation you want to perform.\n1. Get Artwork By Id\n2. Add Artwork to Favourite\n3. Remove artwork from favourites\n4. Search Artwork By Artist\n6. Exit.\n");
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                v.GetArtworkById();
                                break;
                            case 2:
                                v.AddArtworkToFavourite();
                                break;
                            case 3:
                                v.RemoveArtworkToFavourite();
                                break;
                            case 4:
                                v.SearchArtworksByArtist();
                                break;
                            case 5:
                                return;
                            default:
                                Console.WriteLine("OOPS...Wrong Choice. Try Again.");
                                break;
                        }
                    }
                }
            }

            if(usertype=="admin")
            {
                while (true)
                {
                    Console.WriteLine("Choose which Operation you want to perform.\n1. Add Artwork\n2. Remove Artwork\n3. Get Artwork By Id\n4. Update Artwork\n5. Search Artwork By Artist\n6. Get User Favourite Artworks\n7. Exit.\n");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            v.AddArtwork();
                            break;
                        case 2:
                            v.RemoveArtwork();
                            break;
                        case 3:
                            v.GetArtworkById();
                            break;
                        case 4:
                            v.UpdateArtwork();
                            break;
                        case 5:
                            v.SearchArtworksByArtist();
                            break;
                        case 6:
                            v.GetUserFavouriteArtworks();
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("OOPS...Wrong Choice. Try Again.");
                            break;
                    }
                }
            }
        }
    }
}
