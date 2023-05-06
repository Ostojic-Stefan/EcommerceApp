namespace api.EntityFrameworkHelpers
{
    public interface IReadWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        Task Remove(int id);
        void Update(TEntity entity);
    }
}