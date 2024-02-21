using Microsoft.AspNetCore.JsonPatch;

namespace Onion.Arq.Application.Interfaces.Repository
{
    public interface IBaseCommandAsyncRepo<T> : IBaseAsyncRepository
    {
        Task<T> CreateAsync(T t);
        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> t);
        Task<T> DeleteAsync(int id);
        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> t);
        Task<T> UpdateAsync(T t);
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> t);
        Task<T> UpdatePatchAsync(int id, JsonPatchDocument d);
    }
}
