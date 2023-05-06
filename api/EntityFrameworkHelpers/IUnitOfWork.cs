namespace api.EntityFrameworkHelpers
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : BaseEntity;
        IReadWriteRepository<TEntity> GetReadWriteRepository<TEntity>() where TEntity : BaseEntity;
    }
}