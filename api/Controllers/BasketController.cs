using api.EntityFrameworkHelpers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BasketService _basketService;
        private readonly ProductService _productService;

        public BasketController(IUnitOfWork unitOfWork, BasketService basketService, ProductService productService)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            string? customerId = GetCustomerId();
            if (customerId is null)
                return NotFound();
            Basket basket = await _basketService.RetrieveBasketAsync(customerId);
            //var products = Mappings.MapFromBasketToProductResponseDto(basket);
            return Ok(Mappings.MapFromBasketToProductResponseDto(basket));
        }

        [HttpPost] 
        public async Task<IActionResult> AddItemToBasket(AddBasketItemDto basketItemDto)
        {
            string? customerId = GetCustomerId();
            if (customerId is null)
                customerId = CreateCustomerId();
            Basket basket = await _basketService.RetrieveBasketAsync(customerId);
            Product? product = await _productService.GetProductByIdAsync(basketItemDto.ProductId);
            if (product is null)
                return NotFound();
            await _basketService.UpdateBasket(basket, product, basketItemDto.Quantity);
            basket = await _basketService.RetrieveBasketAsync(customerId);
            return CreatedAtAction(nameof(GetBasket), Mappings.MapFromBasketToProductResponseDto(basket));
        }

        private string? GetCustomerId()
        {
            return Request.Cookies["CustomerId"];
        }

        private string CreateCustomerId()
        {
            var customerId = Guid.NewGuid().ToString();
            Response.Cookies.Append("CustomerId", customerId, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                SameSite = SameSiteMode.None,
                Secure = true,
                IsEssential = true
            });
            return customerId;
        }
    }
}