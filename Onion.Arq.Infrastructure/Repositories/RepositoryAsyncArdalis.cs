using Ardalis.Specification.EntityFrameworkCore;
using Onion.Arq.Application.Interfaces;
using Onion.Arq.Infrastructure.Persistence;

namespace Onion.Arq.Infrastructure.Repositories
{
    public class RepositoryAsyncArdalis<T>: RepositoryBase<T>, IRepositoryAsyncArdalis<T> where T : class
    {
        private readonly OnionArqDbContext _dbContext;
        public RepositoryAsyncArdalis(OnionArqDbContext dbContext) : base(dbContext) => _dbContext = dbContext;
    }
}
