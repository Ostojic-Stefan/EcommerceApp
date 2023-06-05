using api.Identity;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly ProductService _productService;
        private readonly ProductImageService _productImageService;

        public ProductsController(ProductService productService, ProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductPaginationParams productPaginationParams)
        {
            var products = await _productService.GetAllProductsAsync(productPaginationParams).ConfigureAwait(false);
            var response = products.Select(Mappings.MapFromProductToProductResponseDto);
            return Ok(response);
        }

        [HttpGet("{categoryName}")]
        public async Task<IActionResult> GetAllProducts(string categoryName)
        {
            var products = await _productService.GetProductsFromCategoryName(categoryName).ConfigureAwait(false);
            var response = products.Select(Mappings.MapFromProductToProductResponseDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id).ConfigureAwait(false);
            if (product is null)
                return NotFound();
            return Ok(Mappings.MapFromProductToProductResponseDto(product));
        }

        [Authorize(Policy = IdentityData.AdminUserClaimName)]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto productDto)
        {
            var product = Mappings.MapFromProductDtoToProduct(productDto);
            Product prod = await _productService.AddProductAsync(product);
            await _productImageService.AddProductImageAsync(
                product,
                productDto.ProductImage.FileName,
                productDto.ProductImage.OpenReadStream()
            ).ConfigureAwait(false);
            return Ok(prod);
        }
    }
}
