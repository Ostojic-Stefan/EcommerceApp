namespace api.EntityFrameworkHelpers
{
    public interface IReadOnlyRepository<TEntity>
        : IRepository<TEntity> where TEntity : BaseEntity
    {
    }
}