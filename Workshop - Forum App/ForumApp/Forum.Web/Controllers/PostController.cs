using Forum.Core.Contracts;
using Forum.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var allPosts = await _postService.GetAllAsync();

                return View(allPosts);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
