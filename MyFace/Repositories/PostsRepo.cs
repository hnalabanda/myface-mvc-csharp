using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyFace.Models.Database;
using MyFace.Models.Request;

namespace MyFace.Repositories
{
    public interface IPostsRepo
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        void CreatePost(CreatePostRequestModel postModel, User postedBy);
    }
    
    public class PostsRepo : IPostsRepo
    {
        private readonly MyFaceDbContext _context;

        public PostsRepo(MyFaceDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Interactions)
                .ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts
                .Include(p => p.User)
                .Single(post => post.Id == id);
        }

        public void CreatePost(CreatePostRequestModel postModel, User postedBy)
        {
            _context.Posts.Add(new Post
            {
                ImageUrl = postModel.ImageUrl,
                Message = postModel.Message,
                PostedAt = DateTime.Now,
                User = postedBy,
            });
            _context.SaveChanges();
        }
    }
}