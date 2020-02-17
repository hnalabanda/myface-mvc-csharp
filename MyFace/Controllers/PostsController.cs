using Microsoft.AspNetCore.Mvc;
using MyFace.Models.Request;
using MyFace.Models.View;
using MyFace.Repositories;

namespace MyFace.Controllers
{
    [Route("/posts")]
    public class PostsController : Controller
    {
        private readonly IPostsRepo _posts;
        private readonly IUsersRepo _users;
        private readonly IInteractionsRepo _interactions;

        public PostsController(IPostsRepo posts, IUsersRepo users, IInteractionsRepo interactions)
        {
            _posts = posts;
            _users = users;
            _interactions = interactions;
        }
        
        [HttpGet("")]
        public IActionResult PostsPage()
        {
            var posts = _posts.GetAll();
            var viewModel = new PostsViewModel(posts);
            return View(viewModel);
        }

        [HttpGet("create")]
        public IActionResult CreatePostPage()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreatePost(CreatePostRequestModel newPost)
        {
            var user = _users.GetById(newPost.UserId);
            _posts.CreatePost(newPost, user);
            return RedirectToAction("PostsPage");
        }

        [HttpPost("{id}/add-interaction")]
        public IActionResult AddInteraction(int id, CreateInteractionRequestModel newInteraction)
        {
            var post = _posts.GetById(id);
            var user = _users.GetById(newInteraction.UserId);
            _interactions.Create(newInteraction, post, user);

            return RedirectToAction("PostsPage");
        }
    }
}