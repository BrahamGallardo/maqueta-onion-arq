namespace Onion.Arq.Application.Interfaces.Repository
{
    public interface IRepositoryCommandAsync<E> : IBaseCommandAsyncRepo<E> where E : class
    {
    }
}
