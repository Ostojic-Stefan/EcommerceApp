using Microsoft.EntityFrameworkCore;

namespace api.EntityFrameworkHelpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, object> _readOnlyRepos = new();
        private readonly Dictionary<Type, object> _readWriteRepos = new();

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_readOnlyRepos.Keys.Contains(typeof(TEntity)))
                return (ReadOnlyRepository<TEntity>)_readOnlyRepos[typeof(TEntity)];

            var repo = new ReadOnlyRepository<TEntity>(_context);
            _readOnlyRepos.Add(typeof(TEntity), repo);
            return repo;
        }

        public IReadWriteRepository<TEntity> GetReadWriteRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_readOnlyRepos.Keys.Contains(typeof(TEntity)))
                return (ReadWriteRepository<TEntity>)_readOnlyRepos[typeof(TEntity)];

            var repo = new ReadWriteRepository<TEntity>(_context);
            _readWriteRepos.Add(typeof(TEntity), repo);
            return repo;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
