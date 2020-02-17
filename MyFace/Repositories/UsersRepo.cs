using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyFace.Models.Database;
using MyFace.Models.Request;

namespace MyFace.Repositories
{
    public interface IUsersRepo
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(CreateUserRequestModel newUser);
    }
    
    public class UsersRepo : IUsersRepo
    {
        private readonly MyFaceDbContext _context;

        public UsersRepo(MyFaceDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .Include(u => u.Posts)
                .Include(u => u.Interactions);
        }

        public User GetById(int id)
        {
            return _context.Users
                .Include(u => u.Posts)
                .Single(user => user.Id == id);
        }

        public void Create(CreateUserRequestModel newUser)
        {
            _context.Users.Add(new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Username = newUser.Username,
                ProfileImageUrl = newUser.ProfileImageUrl,
                CoverImageUrl = newUser.CoverImageUrl,
            });
            _context.SaveChanges();
        }
    }
}