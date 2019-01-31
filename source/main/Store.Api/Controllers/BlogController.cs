using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services;
using Store.Core.Services.Blog;

namespace Store.Api.Controllers {
    [Route ("api/[controller]")]
    public class BlogController : Controller {

        private readonly IBlogService _blogService;
        public BlogController (IBlogService blogService) {
            _blogService = blogService;
        }

        [HttpGet ("")]
        public async Task<IActionResult> Get () {
            var posts = await _blogService.GetPostsAsync ();
            return Json (posts);
        }
    }
}