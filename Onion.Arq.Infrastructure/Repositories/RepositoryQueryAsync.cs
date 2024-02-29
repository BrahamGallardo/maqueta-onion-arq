using Onion.Arq.Application.Interfaces.Repository;
using Onion.Arq.Infrastructure.Persistence;

namespace Onion.Arq.Infrastructure.Repositories
{
    public class RepositoryQueryAsync<E>(OnionArqDbContext context) : BaseQueryAsyncRepo<E>(context), IRepositoryQueryAsync<E> where E : class
    {
    }
}
