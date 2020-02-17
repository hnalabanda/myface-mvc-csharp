using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFace.Models.Database;

namespace MyFace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);
            
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<MyFaceDbContext>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var users = GetSampleUsers();
                context.Users.AddRange(users);
                context.SaveChanges();

                var posts = GetSamplePosts();
                context.Posts.AddRange(posts);
                context.SaveChanges();

                var interactions = GetSampleInteractions();
                context.Interactions.AddRange(interactions);
                context.SaveChanges();
            }
        }

        private static List<Interaction> GetSampleInteractions()
        {
            return new List<Interaction>
            {
                
            };
        }

        private static List<Post> GetSamplePosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Message = "Multi-tiered fault-tolerant flexibility",
                    ImageUrl = "https://i.picsum.photos/id/300/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 5
                },
                new Post
                {
                    Message = "Open-source 4th generation throughput",
                    ImageUrl = "https://i.picsum.photos/id/301/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 5
                },
                new Post
                {
                    Message = "Upgradable actuating extranet",
                    ImageUrl = "https://i.picsum.photos/id/302/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 5
                },
                new Post
                {
                    Message = "Operative optimal conglomeration",
                    ImageUrl = "https://i.picsum.photos/id/303/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 5
                },
                new Post
                {
                    Message = "Persevering maximized model",
                    ImageUrl = "https://i.picsum.photos/id/304/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 5
                },
                new Post
                {
                    Message = "Up-sized tangible contingency",
                    ImageUrl = "https://i.picsum.photos/id/305/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 1
                },
                new Post
                {
                    Message = "Exclusive optimal algorithm",
                    ImageUrl = "https://i.picsum.photos/id/306/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 1
                },
                new Post
                {
                    Message = "Profound neutral local area network",
                    ImageUrl = "https://i.picsum.photos/id/307/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 2
                },
                new Post
                {
                    Message = "Devolved directional flexibility",
                    ImageUrl = "https://i.picsum.photos/id/308/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 2
                },
                new Post
                {
                    Message = "Polarised context-sensitive access",
                    ImageUrl = "https://i.picsum.photos/id/309/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 2
                },
                new Post
                {
                    Message = "Total cohesive circuit",
                    ImageUrl = "https://i.picsum.photos/id/310/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 2
                },
                new Post
                {
                    Message = "Compatible reciprocal array",
                    ImageUrl = "https://i.picsum.photos/id/311/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 3
                },
                new Post
                {
                    Message = "Public-key neutral product",
                    ImageUrl = "https://i.picsum.photos/id/312/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 3
                },
                new Post
                {
                    Message = "Cross-platform intangible hardware",
                    ImageUrl = "https://i.picsum.photos/id/313/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 3
                },
                new Post
                {
                    Message = "Assimilated explicit array",
                    ImageUrl = "https://i.picsum.photos/id/314/1280/960.jpg",
                    PostedAt = DateTime.Now,
                    UserId = 4
                },
                new Post
                {
                    Message = "Adaptive bandwidth-monitored throughput",
                    ImageUrl = "https://i.picsum.photos/id/315/1280/960.jpg",
                    UserId = 4,
                    PostedAt = DateTime.Now,
                },
            };
        }

        private static List<User> GetSampleUsers()
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}