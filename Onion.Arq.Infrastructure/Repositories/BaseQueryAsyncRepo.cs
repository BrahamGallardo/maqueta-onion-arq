using Microsoft.EntityFrameworkCore;
using Onion.Arq.Application.Common;
using Onion.Arq.Application.Interfaces;
using Onion.Arq.Application.Interfaces.Repository;

namespace Onion.Arq.Infrastructure.Repositories
{
    public class BaseQueryAsyncRepo<E>(DbContext context) : BaseAsyncRepository<E>(context), IBaseQueryAsyncRepo<E> 
        where E : class
    {
        public async Task<E> GetByIdAsync(int id)
        {
            var e = await _context.Set<E>().FindAsync(id);
            return e;
        }

        public async Task<PaginatedList<E>> GetPaginatedAsync()
        {
            var e = await _context.Set<E>().ToListAsync();
            return new PaginatedList<E>(e, 0, 0, 0);
        }

        public async Task<List<E>> ListAsync()
        {
            var e = await _context.Set<E>().ToListAsync();
            return new List<E>(e);
        }

        public async Task<List<E>> ListAsync(ISpecification<E> spec)
        {
            if (spec.Criteria is null)
                return new List<E>(null);

            IQueryable<E> queryableResult = (spec.IgnoreQueryFilters) ?
                _context.Set<E>().IgnoreQueryFilters().Where(spec.Criteria).AsNoTracking() :
                _context.Set<E>().Where(spec.Criteria).AsNoTracking();

            var count = 0;
            if (spec.IsPagingEnabled)
                count = await queryableResult.CountAsync();

            queryableResult = spec.Includes
                .Aggregate(
                    queryableResult,
                    (current, include) => current.Include(include));



            // modify the IQueryable to include any string-based include statements
            queryableResult = spec.IncludeStrings
                .Aggregate(
                    queryableResult,
                    (current, include) => current.Include(include));


            if (spec.OrderBy is not null)
                queryableResult = queryableResult.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending is not null)
                queryableResult = queryableResult.OrderByDescending(spec.OrderByDescending);


            var skip = (spec.PageNumber - 1) * spec.PageSize;
            var take = spec.PageSize;


            if (spec.IsPagingEnabled)
                queryableResult = queryableResult.Skip(skip).Take(take);

            return new List<E>(await queryableResult.AsNoTracking().ToListAsync());
        }

        public async Task<PaginatedList<E>> GetPaginatedAsync(ISpecification<E> spec)
        {
            if (spec.Criteria is null)
                return new PaginatedList<E>(null, 0, 0, 0);

            IQueryable<E> queryableResult = (spec.IgnoreQueryFilters) ?
                _context.Set<E>().IgnoreQueryFilters().Where(spec.Criteria).AsNoTracking() :
                _context.Set<E>().Where(spec.Criteria).AsNoTracking();

            var count = 0;
            if (spec.IsPagingEnabled)
                count = await queryableResult.CountAsync();

            queryableResult = spec.Includes
                .Aggregate(
                    queryableResult,
                    (current, include) => current.Include(include));



            // modify the IQueryable to include any string-based include statements
            queryableResult = spec.IncludeStrings
                .Aggregate(
                    queryableResult,
                    (current, include) => current.Include(include));


            if (spec.OrderBy is not null)
                queryableResult = queryableResult.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending is not null)
                queryableResult = queryableResult.OrderByDescending(spec.OrderByDescending);


            var skip = (spec.PageNumber - 1) * spec.PageSize;
            var take = spec.PageSize;


            if (spec.IsPagingEnabled)
                queryableResult = queryableResult.Skip(skip).Take(take);

            return new PaginatedList<E>(await queryableResult.AsNoTracking().ToListAsync(), count, spec.PageNumber, spec.PageSize);
        }

        public async Task<Int32> CountAsync(ISpecification<E> spec)
        {
            if (spec.Criteria is null)
                return 0;

            IQueryable<E> queryableResult = (spec.IgnoreQueryFilters) ?
                _context.Set<E>().IgnoreQueryFilters().Where(spec.Criteria) :
                _context.Set<E>().Where(spec.Criteria);

            return await queryableResult.CountAsync();
        }
    }
}
