using CSharpFunctionalExtensions;

namespace ContactManager.Domain.Abstractions
{
    public interface IWriteRepository<T, TId>
    {
        Task<Result> AddAsync(T entity);
        Task<Result<bool>> RemoveAsync(TId id);
        Task<Result> UpdateAsync(T entity, TId id);
        Task SaveChangesAsync();
    }
}