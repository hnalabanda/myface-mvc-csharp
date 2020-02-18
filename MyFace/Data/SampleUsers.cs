using System.Collections.Generic;
using MyFace.Models.Database;

namespace MyFace.Data
{
    public static class SampleUsers
    {
        public static IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    FirstName = "Gard",
                    LastName = "Fundell",
                    Username = "gfundell0",
                    Email = "gfundell0@drupal.org",
                    ProfileImageUrl = "https://i.picsum.photos/id/100/480/640.jpg",
                    CoverImageUrl = "https://i.picsum.photos/id/200/1280/480.jpg",
                },
                new User
                {
                    FirstName = "Malissa",
                    LastName = "Shuttle",
                    Username = "mshuttle1",
                    Email = "mshuttle1@about.me",
                    ProfileImageUrl = "https://i.picsum.photos/id/101/480/640.jpg",
                    CoverImageUrl = "https://i.picsum.photos/id/201/1280/480.jpg",
                },
                new User
                {
                    FirstName = "Mabelle",
                    LastName = "Vereker",
                    Username = "mvereker2",
                    Email = "mvereker2@t.co",
                    ProfileImageUrl = "https://i.picsum.photos/id/102/480/640.jpg",
                    CoverImageUrl = "https://i.picsum.photos/id/202/1280/480.jpg",
                },
                new User
                {
                    FirstName = "Harmon",
                    LastName = "Winsley",
                    Username = "hwinsley3",
                    Email = "hwinsley3@mashable.com",
                    ProfileImageUrl = "https://i.picsum.photos/id/103/480/640.jpg",
                    CoverImageUrl = "https://i.picsum.photos/id/203/1280/480.jpg",
                },
                new User
                {
                    FirstName = "Annamaria",
                    LastName = "Cruttenden",
                    Username = "acruttenden4",
                    Email = "acruttenden4@ucoz.ru",
                    ProfileImageUrl = "https://i.picsum.photos/id/104/480/640.jpg",
                    CoverImageUrl = "https://i.picsum.photos/id/204/1280/480.jpg",
                },
            };
        }
    }
}