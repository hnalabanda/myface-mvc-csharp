using System;
using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.View
{
    public class PostViewModel
    {
        private readonly Post _post;

        public PostViewModel(Post post)
        {
            _post = post;
            LikedBy = post.Interactions
                .Where(interaction => interaction.Type == InteractionType.LIKE)
                .Select(interaction => new UserViewModel(interaction.User));
            DislikedBy = post.Interactions
                .Where(interaction => interaction.Type == InteractionType.DISLIKE)
                .Select(interaction => new UserViewModel(interaction.User));
        }
        
        public int Id => _post.Id;
        public string Message => _post.Message;
        public string ImageUrl => _post.ImageUrl;
        public DateTime PostedAt => _post.PostedAt;
        public UserViewModel PostedBy => new UserViewModel(_post.User);
        
        public IEnumerable<UserViewModel> LikedBy { get; }
        public IEnumerable<UserViewModel> DislikedBy { get; }
    }
}