using Microsoft.EntityFrameworkCore;
using SaleSystem.DAL.Context;
using SaleSystem.DAL.Interfaces;
using System.Linq.Expressions;

namespace SaleSystem.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DBSALEContext _context;

        public GenericRepository(DBSALEContext context)
        {
            _context = context;
        }

        public async Task<T> GetBy(Expression<Func<T, bool>> filter)
        {
            try
            {
                T entity = await _context.Set<T>().FirstOrDefaultAsync(filter);
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<T>> MakeQuery(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                IQueryable<T> query = filter == null ? _context.Set<T>() : _context.Set<T>()
                    .Where(filter);

                return query;
            }
            catch
            {
                throw;
            }
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Edit(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }
    }
}