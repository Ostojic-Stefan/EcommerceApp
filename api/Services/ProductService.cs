using api.EntityFrameworkHelpers;
using api.Extensions;
using api.Models;
using api.QueryStringHelpers;
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

        public async Task<PagedResponse<Product>> GetAllProductsAsync(ProductPaginationParams productPaginationParams)
        {
            var productRepo = _unitOfWork.GetReadOnlyRepository<Product>();

            var products = productRepo
                .Query()
                .SearchProduct(productPaginationParams.SearchTerm)
                .FilterProducts(productPaginationParams.FilterParams)
                .SortProducts(productPaginationParams.SortTerm)
                .Include(x => x.Category)
                .Include(x => x.ProductImage);

            var pagedResult = await PagedResponse<Product>.GetPagedResponse(products, productPaginationParams.PaginationParams);

            return pagedResult;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var productRepo = _unitOfWork.GetReadOnlyRepository<Product>();
            return await productRepo
                .Query()
                .Include(x => x.Category)
                .Include(x => x.ProductImage)
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }
    }
}
