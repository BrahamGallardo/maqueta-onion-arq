using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Onion.Arq.Application.Interfaces.Repository;

namespace Onion.Arq.Infrastructure.Repositories
{
    public class BaseCommandAsyncRepo<E>(DbContext context) : BaseAsyncRepository<E>(context), IBaseCommandAsyncRepo<E>
        where E : class
    {
        public virtual async Task<E> CreateAsync(E t)
        {
            try
            {
                await _context.Set<E>().AddAsync(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }

        public async Task<E> DeleteAsync(int id)
        {
            var e = await _context.Set<E>().FindAsync(id);
            if (e == null)
                return e;

            _context.Set<E>().Remove(e);
            await _context.SaveChangesAsync();

            return e;
        }

        public async Task<E> UpdateAsync(E t)
        {
            try
            {
                var entry = _context.Set<E>().Attach(t).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<E>> CreateRangeAsync(IEnumerable<E> t)
        {
            try
            {
                await _context.Set<E>().AddRangeAsync(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<E>> DeleteRangeAsync(IEnumerable<E> t)
        {
            try
            {
                _context.Set<E>().RemoveRange(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<E>> UpdateRangeAsync(IEnumerable<E> t)
        {
            try
            {
                //_context.Set<E>().AttachRange(t);
                _context.Set<E>().UpdateRange(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }

        public async Task<E> UpdatePatchAsync(int id, JsonPatchDocument d)
        {
            try
            {
                var t = await _context.FindAsync<E>(id);

                if (t != null)
                {
                    d.ApplyTo(t);
                    _ = _context.Set<E>().Attach(t).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return t;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }
    }
}
