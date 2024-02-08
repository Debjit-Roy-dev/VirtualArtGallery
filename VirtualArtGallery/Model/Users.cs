﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Model
{
    internal class Users
    {
        private int userId;
        private string userName;
        private string password;
        private string email;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string profilePicture;
        private List<int> favouriteArtworks;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public string ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; }
        }
        public List<int> FavouriteArtworks
        {
            get { return favouriteArtworks;}
            set { favouriteArtworks = value;}
        }
        public Users() { }
        public Users(int userId, string userName, string password, string email, string firstName, string lastName, DateTime dateOfBirth, string profilePicture, List<int> favouriteArtworks)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            ProfilePicture = profilePicture;
            FavouriteArtworks = favouriteArtworks;
            
        }
    }
}
