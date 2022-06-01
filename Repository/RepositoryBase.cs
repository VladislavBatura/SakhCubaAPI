using Contracts.Interfaces;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SakhCubaContext SakhCubaContext { get; set; }

        public RepositoryBase(SakhCubaContext sakhCubaContext)
        {
            SakhCubaContext = sakhCubaContext;
        }

        public void Create(T entity)
        {
            SakhCubaContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            SakhCubaContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return SakhCubaContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAll(Expression<Func<T, object>> includes)
        {
            return SakhCubaContext.Set<T>().Include(includes).AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return SakhCubaContext.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> includes)
        {
            return SakhCubaContext.Set<T>().Include(includes).Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            SakhCubaContext.Set<T>().Update(entity);
        }
    }
}
