using VirtualArtGallery.Model;
using VirtualArtGallery.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; 
using VirtualArtGallery.Exception;


namespace VirtualArtGallery.Repository
{
    public class VirtualArtGalleryRepositoryImpl : IVirtualArtGalleryRepository
    {
        public string connectionString;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public VirtualArtGalleryRepositoryImpl()
        {
            sqlconnection = new SqlConnection(DBConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public bool addArtwork(Artwork artwork)
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "Insert into Artwork values(@artworkId,@title,@description,@creationDate,@medium,@imageUrl,@artistId)";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@artworkId", artwork.ArtworkId);
                cmd.Parameters.AddWithValue("@title", artwork.Title);
                cmd.Parameters.AddWithValue("@description", artwork.Description);
                cmd.Parameters.AddWithValue("@creationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@imageUrl", artwork.ImageUrl);
                cmd.Parameters.AddWithValue("@artistId", artwork.ArtistId);
                int addArtworkStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (addArtworkStatus > 0) return true;
                else return false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }   
        }
        public bool removeArtwork(int artworkId)
        {
            sqlconnection.Open();
            cmd.CommandText = "Delete from Artwork where ArtworkId = @artworkId";
            cmd.Connection = sqlconnection;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@artworkId", artworkId);
            int removeArtworkStatus = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            if (removeArtworkStatus > 0)
            {
                Console.WriteLine("Artwork Removed.");
                return true;
            }
            else
            {
                throw new ArtWorkNotFoundException($"Artwork with ArtworkId {artworkId} not found.");
            }
            
        }

        public Artwork getArtworkById(int artworkId)
        {
            sqlconnection.Open();
            cmd.CommandText = "select * from Artwork where ArtworkId = @artworkId";
            cmd.Connection = sqlconnection;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@artworkId", artworkId);
            Artwork artwork = new Artwork();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    artwork.ArtworkId = (int)reader["ArtworkId"];
                    artwork.Title = (string)reader["Title"];
                    artwork.Description = (string)reader["Description"];
                    artwork.CreationDate = (DateTime)reader["CreationDate"];
                    artwork.Medium = (string)reader["Medium"];
                    artwork.ImageUrl = (string)reader["ImageUrl"];
                    artwork.ArtistId = (int)reader["ArtistId"];
                    sqlconnection.Close();
                    return artwork;
                }
                else
                {
                    sqlconnection.Close();
                    throw new ArtWorkNotFoundException($"Artwork with ArtworkId {artworkId} not found.");

                }
            }

        }
        public bool addArtworkToFavourite(int userId, int artWorkId)
        {
            try
            {
                sqlconnection.Open();

                cmd.CommandText = "select Favourite_Artworks from Users where User_id = @user";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@user", userId);
                string favourite_artwork="";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read()) {
                        favourite_artwork = (string)reader["Favourite_Artworks"];
                    }
                    else
                    {
                        sqlconnection.Close();
                        throw new UserNotFoundException($"No User Found with user Id{userId}");
                    }
                }
                sqlconnection.Close();

                string result = string.Concat(favourite_artwork ,",", artWorkId.ToString());

                sqlconnection.Open ();
                cmd.CommandText = "Insert into UserFavouriteArtwork values(@userId,@artworkId);"+
                    "update Users set Favourite_Artworks = @result where User_id= @userId";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@artworkId", artWorkId);
                cmd.Parameters.AddWithValue("@result", result);
                int adduserfavartworkStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (adduserfavartworkStatus > 0) return true;
                else
                {
                    throw new ArtWorkNotFoundException($"No Artwork Found with Artwork Id{artWorkId}");
                }
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        
        }
        public bool removeArtworkToFavourite(int userId, int artWorkId)
        {
            try
            {
                sqlconnection.Open();

                cmd.CommandText = "select Favourite_Artworks from Users where User_id = @user";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@user", userId);
                string favourite_artwork = "";
                string result = "";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        favourite_artwork = (string)reader["Favourite_Artworks"];
                    }
                    else
                    {
                        sqlconnection.Close();
                        throw new UserNotFoundException($"No User Found with user Id{userId}");
                    }
                }
                int[] favartworkids = favourite_artwork.Split(',').Select(int.Parse).ToArray();
                foreach(int artworkid in favartworkids)
                {
                    if (artworkid != artWorkId)
                    {
                        result = result + artworkid.ToString()+",";
                    }
                }
                result = result.Remove(result.Length-1);
                cmd.CommandText = "delete from UserFavouriteArtwork where UserId=@userId and ArtworkId=@artworkId;" +
                    "update Users set Favourite_Artworks = @result where User_id= @userId";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@artworkId", artWorkId);
                cmd.Parameters.AddWithValue("@result", result);
                int adduserfavartworkStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (adduserfavartworkStatus > 0) return true;
                else
                {
                    throw new ArtWorkNotFoundException($"No Artwork Found with Artwork Id{userId}");
                }
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }

        }
        public bool updateArtwork(Artwork artwork, int artworkId)
        {
            sqlconnection.Open();
            cmd.CommandText = "update Artwork set Title = @title,Description = @description,CreationDate = @creationDate,Medium = @medium,ImageUrl = @imageUrl,ArtistId =@artistId where ArtworkId=@ArtworkId";
            cmd.Connection = sqlconnection;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@artworkId", artwork.ArtworkId);
            cmd.Parameters.AddWithValue("@title", artwork.Title);
            cmd.Parameters.AddWithValue("@description", artwork.Description);
            cmd.Parameters.AddWithValue("@creationDate", artwork.CreationDate);
            cmd.Parameters.AddWithValue("@medium", artwork.Medium);
            cmd.Parameters.AddWithValue("@imageUrl", artwork.ImageUrl);
            cmd.Parameters.AddWithValue("@artistId", artwork.ArtistId);
            int updateArtworkStatus = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            if (updateArtworkStatus > 0) return true;
            else
            {
                throw new ArtWorkNotFoundException($"No Artwork found with Artwork Id {artworkId}");
            }
        }
        public List<Artwork> searchArtworksbyArtist(string artist)
        {
            try
            {
                List<Artwork> artworks = new List<Artwork>();
                cmd.CommandText = "select * from Artwork join Artist on Artwork.ArtistId=Artist.ArtistId where Artist.Name = @name;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", artist);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    Artwork artwork = new Artwork();
                    artwork.ArtworkId = (int)reader["ArtworkId"];
                    artwork.Title = (string)reader["Title"];
                    artwork.Description = (string)reader["Description"];
                    artwork.CreationDate = (DateTime)reader["CreationDate"];
                    artwork.Medium = (string)reader["Medium"];
                    artwork.ImageUrl = (string)reader["ImageUrl"];
                    artwork.ArtistId = (int)reader["ArtistId"];
                    artworks.Add(artwork);
                    count++;
                }
                sqlconnection.Close();
                if (count == 0)
                {
                    throw new ArtWorkNotFoundException($"No Artwork found of Artist {artist}");
                }
                else return artworks;
            }
            catch (System.Exception ex)
            {
                
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public List<Artwork> getUserFavouriteArtworks(int userId)
        {
            try
            {
                List<Artwork> artworks = new List<Artwork>();
                cmd.CommandText = "select * from Artwork where artworkId in(select ArtworkId from UserFavouriteArtwork where USerId = @userId);";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    Artwork artwork = new Artwork();
                    artwork.ArtworkId = (int)reader["ArtworkId"];
                    artwork.Title = (string)reader["Title"];
                    artwork.Description = (string)reader["Description"];
                    artwork.CreationDate = (DateTime)reader["CreationDate"];
                    artwork.Medium = (string)reader["Medium"];
                    artwork.ImageUrl = (string)reader["ImageUrl"];
                    artwork.ArtistId = (int)reader["ArtistId"];
                    artworks.Add(artwork);
                    count++;
                }
                sqlconnection.Close();
                if (count > 0)
                {
                    return artworks;
                }
                else
                {
                    throw new UserNotFoundException($"No User Found with user id {userId}");
                }
            }
            catch (System.Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public bool createGallery(Gallery gallery)
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "Insert into Gallery values(@galleryId,@name,@description,@location,@curator,@openinghours)";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@galleryId", gallery.GalleryId);
                cmd.Parameters.AddWithValue("@name", gallery.Name);
                cmd.Parameters.AddWithValue("@description", gallery.Description);
                cmd.Parameters.AddWithValue("@location", gallery.Location);
                cmd.Parameters.AddWithValue("@curator", gallery.Curator);
                cmd.Parameters.AddWithValue("@openinghours", gallery.OpeningHours);
                
                int addGalleryStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (addGalleryStatus > 0) return true;
                else return false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public bool updateGallery(Gallery gallery, int galleryId)
        {
            sqlconnection.Open();
            cmd.CommandText = "update Gallery set Name = @name,Description = @description,Location = @location,Curator= @curator,OpeningHours= @openinghours where Gallery_id=@galleryId";
            cmd.Connection = sqlconnection;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@galleryId", gallery.GalleryId);
            cmd.Parameters.AddWithValue("@name", gallery.Name);
            cmd.Parameters.AddWithValue("@description", gallery.Description);
            cmd.Parameters.AddWithValue("@location", gallery.Location);
            cmd.Parameters.AddWithValue("@curator", gallery.Curator);
            cmd.Parameters.AddWithValue("@openinghours", gallery.OpeningHours);
            int updateGalleryStatus = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            if (updateGalleryStatus > 0) return true;
            else
            {
                throw new GalleryNotFoundException($"No Gallery found with Gallery Id {galleryId}");
            }
        }

        public bool removeGallery(int galleryId)
        {
            sqlconnection.Open();
            cmd.CommandText = "Delete from Gallery where Gallery_id = @galleryId";
            cmd.Connection = sqlconnection;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@galleryId", galleryId);
            int removeGalleryStatus = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            if (removeGalleryStatus > 0)
            {
                Console.WriteLine("Gallery Removed.");
                return true;
            }
            else
            {
                throw new GalleryNotFoundException($"Gallery with Gallery Id {galleryId} not found.");
            }
        }
        public Gallery getGalleryById(int galleryId)
        {
            sqlconnection.Open();
            cmd.CommandText = "select * from Gallery where Gallery_id = @galleryId";
            cmd.Connection = sqlconnection;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@galleryId", galleryId);
            Gallery gallery = new Gallery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    gallery.GalleryId = galleryId;
                    gallery.Name = (string)reader["Name"];
                    gallery.Description = (string)reader["description"];
                    gallery.Location = (string)reader["location"];
                    gallery.Curator = (int)reader["curator"];
                    gallery.OpeningHours = (string)reader["openingHours"];
                    sqlconnection.Close();
                    return gallery;
                }
                else
                {
                    sqlconnection.Close();
                    throw new GalleryNotFoundException($"Artwork with ArtworkId {galleryId} not found.");

                }
            }
        }
        public string verifyUser(string username, string password)
        {
            sqlconnection.Open ();
            cmd.CommandText = "select password,roles from Users where Username = @username;";
            cmd.Connection = sqlconnection;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@username", username);

            string userPassword = "";
            string roles = "";
            using(SqlDataReader reader= cmd.ExecuteReader())
            {
                if(reader.Read())
                {
                    userPassword = reader["Password"].ToString();
                    roles = reader["roles"].ToString();
                }
                else
                {
                    Console.WriteLine("User Not Found.");
                    sqlconnection.Close();
                    return "unknown";
                }
            }
            sqlconnection.Close();
            if (password==userPassword)
            {
                
                return roles;
            }
            else
            {
                Console.WriteLine("Wrong Password.");
                return "unknown";
            }
        }
    }
}
