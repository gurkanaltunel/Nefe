using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nefe.Service.Repository.Interface
{
    public interface IGenericNefeRepository<T> where T : class
    {
        T FindById(int id);
        IEnumerable<T> Select(Expression<Func<T, bool>> filter = null);
        T Insert(T entity);
        bool Delete(int id);
    }
}
