using Onion.Arq.Application.Interfaces;
using Onion.Arq.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Onion.Arq.Infrastructure.Persistence
{
    public partial class OnionArqDbContext : BaseDbContext, IOnionArqDbContext
    {
        private IHttpContextAccessor _context;
        public OnionArqDbContext(DbContextOptions<OnionArqDbContext> options
            , IHttpContextAccessor context) : base(options, context)
        {
            _context = context;
        }

        #region Set Entities
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(ent =>
            {
                ent.ToTable("roles");

                ent.HasData(
                    new Role { Id = 1, Name = "Admin", Activated = true, CreatedDate = new DateTime(2023 - 11 - 01), Description = "All Permissions", CreatedBy = "" },
                    new Role { Id = 2, Name = "User", Activated = true, CreatedDate = new DateTime(2023 - 11 - 01), Description = "Create, Edit, View", CreatedBy = "" });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email).IsUnique(true);

                entity.HasData(new User { Id = 1, Activated = true, CreatedDate = new DateTime(2023 - 11 - 06), Email = "agallardo@tekssolutions.com", CreatedBy = "", LastName = "Gallardo", Name = "Abraham", Password = "123456", RoleId = 1 });
            });

            modelBuilder.Entity<Session>(ent =>
            {
                ent.ToTable("session");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
