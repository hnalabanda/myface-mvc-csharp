using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.View
{
    public class UserViewModel
    {
        private readonly User _user;

        public UserViewModel(User user)
        {
            _user = user;
            Posts = user.Posts.Select(post => new PostViewModel(post));
            Likes = user.Interactions
                .Where(interaction => interaction.Type == InteractionType.LIKE)
                .Select(interaction => new PostViewModel(interaction.Post));
            Dislikes = user.Interactions
                .Where(interaction => interaction.Type == InteractionType.DISLIKE)
                .Select(interaction => new PostViewModel(interaction.Post));
        }

        public int Id => _user.Id;
        public string FirstName => _user.FirstName;
        public string LastName => _user.LastName;
        public string DisplayName => $"{FirstName} {LastName}";
        public string Username => _user.Username;
        public string Email => _user.Email;
        public string ProfileImageUrl => _user.ProfileImageUrl;
        public string CoverImageUrl => _user.CoverImageUrl;
        
        public IEnumerable<PostViewModel> Posts { get; }
        public IEnumerable<PostViewModel> Likes { get; }
        public IEnumerable<PostViewModel> Dislikes { get; }
    }
}