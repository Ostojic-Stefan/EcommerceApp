using Microsoft.EntityFrameworkCore;

namespace api.EntityFrameworkHelpers
{
    public class ReadWriteRepository<TEntity>
        : IReadWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public ReadWriteRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _context.Set<TEntity>()
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }

        public async Task Remove(int id)
        {
            var foundEntity = await _context.Set<TEntity>()
                .SingleAsync(entity => entity.Id == id);
            _context.Set<TEntity>().Remove(foundEntity);
        }

        public void Update(TEntity entity)
        {
            // attaches the entity to the tracking graph
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}