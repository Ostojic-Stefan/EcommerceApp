using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProductsAsync().ConfigureAwait(false));
        }

        [HttpGet("{categoryName}")]
        public async Task<IActionResult> GetAllProducts(string categoryName)
        {
            return Ok(await _productService.GetProductsFromCategoryName(categoryName).ConfigureAwait(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id).ConfigureAwait(false);
            if (product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto productDto)
        {
            var product = Mappings.MapFromProductDtoToProduct(productDto);
            await _productService.AddProductAsync(product).ConfigureAwait(false);
            return Ok();
        }
    }
}