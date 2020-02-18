using System;
using System.Collections.Generic;
using MyFace.Models.Database;

namespace MyFace.Data
{
    public static class SampleInteractions
    {
        public static IEnumerable<Interaction> GetInteractions()
        {
            return new List<Interaction>
            {
                new Interaction
                {
                    Type = InteractionType.LIKE,
                    Date = DateTime.Now,
                    PostId = 1,
                    UserId = 1,
                },
                new Interaction
                {
                    Type = InteractionType.LIKE,
                    Date = DateTime.Now,
                    PostId = 8,
                    UserId = 2,
                },
                new Interaction
                {
                    Type = InteractionType.LIKE,
                    Date = DateTime.Now,
                    PostId = 4,
                    UserId = 3,
                },
                new Interaction
                {
                    Type = InteractionType.DISLIKE,
                    Date = DateTime.Now,
                    PostId = 4,
                    UserId = 4,
                },
                new Interaction
                {
                    Type = InteractionType.LIKE,
                    Date = DateTime.Now,
                    PostId = 7,
                    UserId = 5,
                },
                new Interaction
                {
                    Type = InteractionType.DISLIKE,
                    Date = DateTime.Now,
                    PostId = 12,
                    UserId = 5,
                },
            };
        }
        
    }
}