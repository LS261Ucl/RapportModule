using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        Task<T> CreateAsync(T entity);

        Task<T> CreateAsync(Expression<Func<T, bool>> criteria, T entity);
        Task<T> UpdateAsync(T entity);
    //   Task<string[]> UpdateConcurrentlyAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
