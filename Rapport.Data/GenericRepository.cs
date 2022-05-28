using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Rapport.BusinessLogig.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Data
{
    public class GenericRepository<T>  : IGenericRepository<T> where T : class
    {
        private readonly ReportDbContext _context;

        public GenericRepository(ReportDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Repository", ex.InnerException);
            }//catch

        }

        public async Task<T> CreateAsync(Expression<Func<T, bool>> criteria, T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Repository", ex.InnerException);
            }//catch
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
                return false;

            _context.Set<T>().Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<T>> FindBySearchText(string searchText, Expression<Func<T, bool>>? criteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (criteria != null)
            {
                query = query.Where(criteria);
            }//if

            if (includes != null)
            {
                query = includes(query);
            }//if

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (criteria != null)
            {
                query = query.Where(criteria);
            }//if

            if (includes != null)
            {
                query = includes(query);
            }//if

            if (orderBy != null)
            {
                query = orderBy(query);
            }//if

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (includes != null)
            {
                query = includes(query);
            }//if

            return await query.AsNoTracking().FirstOrDefaultAsync(criteria);
        }


        public async Task<T> UpdateAsync(T entity)
        {
            try
            {

                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }//try
            catch (Exception ex)
            {
                throw new Exception("kunne ikke få fat i repository", ex);
            }//catch
        }

        public async Task<string[]> UpdateConcurrentlyAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return new[] { "" };
            }//try
            catch (DbUpdateConcurrencyException e)
            {
                return new[]
                {
                    "Den entitet, som du forsøgte at redigere," +
                    " blev ændret af en anden bruger, efter at du fik den oprindelige værdi. " +
                    "Redigeringshandlingen blev annulleret. Hvis du stadig vil redigere denne entitet, " +
                    "så tryk tilbage og find entiteten igen.",
                    e.Message, "409"
                };
            }//catch
        }
    }
}
