using DOWNNOTIFIER.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.Repository.Concrete
{
    public class BaseEFRepository<T> : IBaseRepository<T>
        where T : class, new()
    {
        protected readonly DbContext _dbContext;
        protected BaseEFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void Insert(T entity)
        {
            _dbContext.Add(entity);
        }

        public IQueryable<T> Select(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
                return _dbContext.Set<T>().AsQueryable();
            return _dbContext.Set<T>().Where(predicate);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
