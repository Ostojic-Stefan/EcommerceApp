using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService) 
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            return Ok(await _categoriesService.GetCategoriesAsync().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoriesService.GetCategoryByIdAsync(id).ConfigureAwait(false);
            if (category is null)
                return NotFound();
            return Ok(category);
        }
    }
}
