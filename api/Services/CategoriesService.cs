using api.EntityFrameworkHelpers;
using api.Models;

namespace api.Services
{
    public class CategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            var categoriesRepo = _unitOfWork.GetReadOnlyRepository<Category>();
            return await categoriesRepo.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var categoriesRepo = _unitOfWork.GetReadOnlyRepository<Category>();
            return await categoriesRepo.GetAsync(id).ConfigureAwait(false);
        }

        public async Task AddCategory(Category category)
        {
            var categoriesRepo = _unitOfWork.GetReadWriteRepository<Category>();
            categoriesRepo.Add(category);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
