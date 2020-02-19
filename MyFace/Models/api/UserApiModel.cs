using System;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.api
{
    public class UserApiModel
    {
        private User _user;

        public UserApiModel(User user)
        {
            _user = user;
        }

        public int Id => _user.Id;
        public string FirstName => _user.FirstName;
        public string LastName => _user.LastName;
        public string DisplayName => $"{FirstName} {LastName}";
        public string Username => _user.Username;
        public string Email => _user.Email;
        public string ProfileImageUrl => _user.ProfileImageUrl;
        public string CoverImageUrl => _user.CoverImageUrl;
        public int NumberOfPosts => _user.Posts.Count;
        public DateTime? DateOfLastPost => _user.Posts.FirstOrDefault()?.PostedAt;
    }
}