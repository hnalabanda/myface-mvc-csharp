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
        IEnumerable<Post> GetAll(int pageNumber, int pageSize);
        void CreatePost(CreatePostRequestModel postModel);
    }
    
    public class PostsRepo : IPostsRepo
    {
        private readonly MyFaceDbContext _context;

        public PostsRepo(MyFaceDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Post> GetAll(int pageNumber, int pageSize)
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Interactions)
                .OrderByDescending(p => p.PostedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public void CreatePost(CreatePostRequestModel postModel)
        {
            _context.Posts.Add(new Post
            {
                ImageUrl = postModel.ImageUrl,
                Message = postModel.Message,
                PostedAt = DateTime.Now,
                UserId = postModel.UserId,
            });
            _context.SaveChanges();
        }
    }
}