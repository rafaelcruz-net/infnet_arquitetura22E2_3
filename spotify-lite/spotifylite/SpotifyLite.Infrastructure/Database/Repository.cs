using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Infrastructure.Database
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task Delete(T entity)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAllByCriteria(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(_set.Where(expression));
        }

        public async Task<T> FindOneByCriteria(Expression<Func<T, bool>> expression)
        {
            return await _set.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Task.FromResult(_set.AsEnumerable());
        }

        public async Task<T> GetById(object id)
        {
            return await _set.FindAsync(id);
        }

        public async Task Save(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
