using System;
using MyFace.Models.Database;
using MyFace.Models.Request;

namespace MyFace.Repositories
{
    public interface IInteractionsRepo
    {
        void Create(CreateInteractionRequestModel newInteraction, int postId);
    }
    
    public class InteractionsRepo : IInteractionsRepo
    {
        private readonly MyFaceDbContext _context;

        public InteractionsRepo(MyFaceDbContext context)
        {
            _context = context;
        }
        
        public void Create(CreateInteractionRequestModel newInteraction, int postId)
        {
            _context.Interactions.Add(new Interaction
            {
                Type = newInteraction.InteractionType,
                PostId = postId,
                UserId = newInteraction.UserId,
                Date = DateTime.Now,
            });
            _context.SaveChanges();
        }
    }
}