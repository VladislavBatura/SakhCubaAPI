using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, object>> includes);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> includes);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
