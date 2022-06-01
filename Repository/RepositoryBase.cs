using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
