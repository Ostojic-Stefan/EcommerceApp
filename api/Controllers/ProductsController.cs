using api.EntityFrameworkHelpers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var repo = _unitOfWork.GetReadOnlyRepository<Product>();
            var allProducts = await repo.GetAllAsync().ConfigureAwait(false);
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var repo = _unitOfWork.GetReadOnlyRepository<Product>();
            var product = await repo.GetAsync(id).ConfigureAwait(false);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllProducts(Product product)
        {
            var repo = _unitOfWork.GetReadWriteRepository<Product>();
            repo.Add(product);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return Ok();
        }

    }
}