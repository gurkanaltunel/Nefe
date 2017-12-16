using System;
using System.Collections.Generic;
using System.Linq;
using Nefe.Service.Repository.Interface;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Nefe.Service.Repository
{
    public class GenericNefeRepository<T> : IGenericNefeRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public GenericNefeRepository(DbContext nefeDataContext)
        {
            _dbSet = nefeDataContext.Set<T>();
        }

        public virtual T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return _dbSet.Where(filter);
            }
            return _dbSet.ToList();
        }

        public T Insert(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            try
            {
                if (entity != null)
                    _dbSet.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
