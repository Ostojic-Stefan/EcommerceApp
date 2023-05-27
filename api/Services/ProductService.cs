using api.EntityFrameworkHelpers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Product>> GetProductsFromCategoryName(string categoryName)
        {
            var productRepo = _unitOfWork.GetReadOnlyRepository<Product>();
            return await productRepo
                .Query()
                .Include(x => x.Category)
                .Where(x => x.Category.Name == categoryName)
                .ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var productRepo = _unitOfWork.GetReadWriteRepository<Product>();
            productRepo.Add(product);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var productRepo = _unitOfWork.GetReadOnlyRepository<Product>();
            return await productRepo
                .Query()
                .Include(x => x.Category)
                .Include(x => x.ProductImage)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var productRepo = _unitOfWork.GetReadOnlyRepository<Product>();
            return await productRepo
                .Query()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }
    }
}
