using Ardalis.Specification;

namespace Onion.Arq.Application.Interfaces
{
    public interface IRepositoryAsyncArdalis<T> : IRepositoryBase<T> where T : class
    {
    }
}
