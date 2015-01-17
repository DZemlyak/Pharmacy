using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pharmacy.Contracts.Repository
{
    public interface IRepository<T> {
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void SaveChanges();
        T GetByPrimaryKey(object key);
    }
}
