using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBlog.Domain.Repository.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null");

            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FindAsync(predicate);
        }
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                return;

            Delete(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
