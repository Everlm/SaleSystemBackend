using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetBy(Expression<Func<T, bool>> filter);
        Task<IQueryable<T>> MakeQuery(Expression<Func<T, bool>> filter = null);
        Task<T> Create(T entity);
        Task<bool> Edit(T entity);
        Task<bool> Delete(T entity);

    }
}
