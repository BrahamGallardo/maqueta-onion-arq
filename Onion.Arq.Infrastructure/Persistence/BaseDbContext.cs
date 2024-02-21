using Onion.Arq.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Onion.Arq.Application.Common.Helpers;

namespace Onion.Arq.Infrastructure.Persistence
{
    public abstract class BaseDbContext : DbContext
    {
        private IHttpContextAccessor _context;

        public BaseDbContext(DbContextOptions options
            , IHttpContextAccessor context) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
        }

        private string? GetCurrentUserId()
        {
            return _context?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = ServerTime.GetServerTimeCST();
                        entry.Entity.UpdatedBy = GetCurrentUserId();
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = ServerTime.GetServerTimeCST();
                        entry.Entity.CreatedBy = GetCurrentUserId();
                        entry.Entity.Activated = true;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
