using Onion.Arq.Application.Interfaces.Repository;
using Onion.Arq.Infrastructure.Persistence;

namespace Onion.Arq.Infrastructure.Repositories
{
    public class RepositoryCommandAsync<E> : BaseCommandAsyncRepo<E>, IRepositoryCommandAsync<E> where E : class
    {
        public RepositoryCommandAsync(OnionArqDbContext context) : base(context) { }
    }
}
