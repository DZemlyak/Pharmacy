using System.Linq;
using Pharmacy.Contracts.Entities;

namespace Pharmacy.Contracts.Manager
{
    public interface IManager<T> where T : class, IDbEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(object key);
        T GetByPrimaryKey(object key);
        IQueryable<T> GetAll();
    }
}
