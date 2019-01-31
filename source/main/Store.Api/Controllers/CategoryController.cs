using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services;
using Store.Core.Services.Category;

namespace Store.Api.Controllers
{
   
        [Route ("api/[controller]")]
    public class CategoryController : Controller {

        private readonly ICategoryService _categoryService;
        public CategoryController (ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet ("")]
        public async Task<IActionResult> Get () {
            var categories = await _categoryService.GetCategoriesAsync ();
            return Json (categories);
        }
    }
}