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
        private readonly IInteractionsRepo _interactions;
        private readonly IUsersRepo _users;

        public PostsController(IPostsRepo posts, IInteractionsRepo interactions,IUsersRepo userrepo)
        {
            _posts = posts;
            _interactions = interactions;
            _users = userrepo;
        }
        
        [HttpGet("")]
        public IActionResult PostsPage(int pageNumber = 0, int pageSize = 10)
        {
            var posts = _posts.GetAll(pageNumber, pageSize);
            var viewModel = new PostsViewModel(posts);
            return View(viewModel);
        }

        [HttpGet("create")]
        public IActionResult CreatePostPage()
        {
            return View();
        }
        
        [HttpGet("GetInfo")]
        public IActionResult GetUserInfo(int id)
        {
            var user= new UsersApiController(_users);
            var userInfo=  user.GetUser(id);
            return View(userInfo);
        }
        
        [HttpPost("create")]
        public IActionResult CreatePost(CreatePostRequestModel newPost)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePostPage", newPost);
            }
            
            _posts.CreatePost(newPost);
            return RedirectToAction("PostsPage");

        }

        [HttpPost("{id}/add-interaction")]
        public IActionResult AddInteraction(int id, CreateInteractionRequestModel newInteraction)
        {
            _interactions.Create(newInteraction, id);
            return RedirectToAction("PostsPage");
        }
    }
}