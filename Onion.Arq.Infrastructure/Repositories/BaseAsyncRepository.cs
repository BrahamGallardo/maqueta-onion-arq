using Microsoft.EntityFrameworkCore;
using Onion.Arq.Application.Interfaces.Repository;

namespace Onion.Arq.Infrastructure.Repositories
{
    public abstract class BaseAsyncRepository<E> : IBaseAsyncRepository
        where E : class
    {
        protected bool _disposed = false;
        protected readonly DbContext _context;
        public BaseAsyncRepository(DbContext context) => _context = context;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                if (_context is null)
                    _context.Dispose();
        }
        public virtual async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }
        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_context is not null)
            {
                await _context.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}
