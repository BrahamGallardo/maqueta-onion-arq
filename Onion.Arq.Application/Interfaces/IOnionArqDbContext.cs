using Onion.Arq.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Onion.Arq.Application.Interfaces
{
    public interface IOnionArqDbContext
    {
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Session> Sessions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
