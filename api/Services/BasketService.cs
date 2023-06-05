using api.EntityFrameworkHelpers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class BasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateBasket(Basket basket, Product product, int quantity)
        {
            if (basket.BasketItems.Any(x => x.ProductId == product.Id))
            {
                BasketItem basketItem = basket.BasketItems.First(x => x.ProductId == product.Id);
                basketItem.Quantity += quantity;
            }
            else
            {
                basket.BasketItems.Add(new BasketItem
                {
                    ProductId = product.Id,
                    Quantity = quantity
                });
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public Basket CreateBasket(string customerId)
        {
            var basketRepo = _unitOfWork.GetReadWriteRepository<Basket>();
            var basket = new Basket
            {
                CustomerId = customerId
            };
            basketRepo.Add(basket);
            return basket;
        }

        public async Task<Basket> GetBasketFromCustomerId(string customerId)
        {
            var basketRepo = _unitOfWork.GetReadOnlyRepository<Basket>();

            Basket basket = await basketRepo.Query()
                .Include(x => x.BasketItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.CustomerId == customerId)
                .SingleAsync();

            return basket;
        }

        public async Task<Basket> RetrieveBasketAsync(string customerId)
        {
            var basketRepo = _unitOfWork.GetReadWriteRepository<Basket>();
            var basket = await basketRepo.Query()
                .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product)
                .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductImage)
                .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.Category)
                .Where(x => x.CustomerId == customerId)
                .FirstOrDefaultAsync();

            return basket is null
                ? CreateBasket(customerId)
                : basket;
        }
    }
}
