using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BS.BusinessLogic.Services
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void Delete(IEnumerable<T> entities);
        T Get(Expression<Func<T, bool>> where);
    }
}
