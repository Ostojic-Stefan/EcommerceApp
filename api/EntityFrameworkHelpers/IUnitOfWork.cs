using Microsoft.EntityFrameworkCore;

namespace api.EntityFrameworkHelpers
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : BaseEntity;
        IReadWriteRepository<TEntity> GetReadWriteRepository<TEntity>() where TEntity : BaseEntity;
    }
}