using Onion.Arq.Application.Common;
using Onion.Arq.Application.Common.Specifications;

namespace Onion.Arq.Application.Interfaces.Repository
{
    public interface IBaseQueryAsyncRepo<T> : IBaseAsyncRepository
    {
        Task<T> GetByIdAsync(int id);
        Task<PaginatedList<T>> GetPaginatedAsync();
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<PaginatedList<T>> GetPaginatedAsync(ISpecification<T> spec);
        //Hace falta el GetBySpec de una sola entidad
        //Checar el CountAsync
    }
}
