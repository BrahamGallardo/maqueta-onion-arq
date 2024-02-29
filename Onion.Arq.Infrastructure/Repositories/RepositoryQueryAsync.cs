﻿using Onion.Arq.Application.Interfaces.Repository;
using Onion.Arq.Infrastructure.Persistence;

namespace Onion.Arq.Infrastructure.Repositories
{
    public class RepositoryQueryAsync<E> : BaseQueryAsyncRepo<E>, IRepositoryQueryAsync<E> where E : class
    {
        public RepositoryQueryAsync(OnionArqDbContext context) : base(context) { }
    }
}
