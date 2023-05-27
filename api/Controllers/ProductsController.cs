using api.EntityFrameworkHelpers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync().ConfigureAwait(false);
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

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto productDto)
        {
            var product = Mappings.MapFromProductDtoToProduct(productDto);
            Product prod = await _productService.AddProductAsync(product);
            ProductImage productImage = await _productImageService.AddProductImageAsync(
                product,
                productDto.ProductImage.FileName,
                productDto.ProductImage.OpenReadStream()
            ).ConfigureAwait(false);
            return Ok();
        }
    }
}
