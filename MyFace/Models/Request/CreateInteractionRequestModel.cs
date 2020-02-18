using System.ComponentModel.DataAnnotations;
using MyFace.Models.Database;

namespace MyFace.Models.Request
{
    public class CreateInteractionRequestModel
    {
        [Required]
        public InteractionType InteractionType { get; set; }
        
        [Required]
        public int UserId { get; set; }
    }
}