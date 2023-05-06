using Microsoft.EntityFrameworkCore;

namespace api.EntityFrameworkHelpers
{
    public class ReadOnlyRepository<TEntity>
        : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public ReadOnlyRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>()
                .AsNoTracking();
        }
    }
}