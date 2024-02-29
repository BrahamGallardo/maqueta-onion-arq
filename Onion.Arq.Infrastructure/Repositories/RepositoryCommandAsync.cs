using Onion.Arq.Application.Interfaces.Repository;
using Onion.Arq.Infrastructure.Persistence;

namespace Onion.Arq.Infrastructure.Repositories
{
    public class RepositoryCommandAsync<E>(OnionArqDbContext context) : BaseCommandAsyncRepo<E>(context), IRepositoryCommandAsync<E> where E : class
    {
    }
}
