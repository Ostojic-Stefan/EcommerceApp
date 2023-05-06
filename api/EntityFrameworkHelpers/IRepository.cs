namespace api.EntityFrameworkHelpers
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query();
        Task<TEntity?> GetAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
    }
}