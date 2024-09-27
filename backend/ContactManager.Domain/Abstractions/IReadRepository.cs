using CSharpFunctionalExtensions;

namespace ContactManager.Domain.Abstractions
{
    public interface IReadRepository<T, TId>
    {
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result<T?>> GetAsync(TId id);
    }
}