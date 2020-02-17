using System;
using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.View
{
    public class PostUserViewModel
    {
        private readonly User _user;

        public PostUserViewModel(User user)
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
    }
    
    public class PostViewModel
    {
        private readonly Post _post;

        public PostViewModel(Post post)
        {
            _post = post;
            PostedBy = new PostUserViewModel(post.User);
            LikedBy = post.Interactions
                .Where(interaction => interaction.Type == InteractionType.LIKE)
                .Select(interaction => new PostUserViewModel(interaction.User));
            DislikedBy = post.Interactions
                .Where(interaction => interaction.Type == InteractionType.DISLIKE)
                .Select(interaction => new PostUserViewModel(interaction.User));
        }
        
        public int Id => _post.Id;
        public string Message => _post.Message;
        public string ImageUrl => _post.ImageUrl;
        public DateTime PostedAt => _post.PostedAt;
        
        public PostUserViewModel PostedBy { get; }
        public IEnumerable<PostUserViewModel> LikedBy { get; }
        public IEnumerable<PostUserViewModel> DislikedBy { get; }
    }
}