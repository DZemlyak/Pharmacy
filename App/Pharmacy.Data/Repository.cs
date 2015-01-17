using System;
using System.Linq;
using Pharmacy.Contracts.Entities;
using Pharmacy.Contracts.Repository;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Pharmacy.Data
{
    public class Repository<T>:IRepository<T> where T: class, IDbEntity {

        private readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public Repository(DataContext context) {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Add(T entity) {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public IQueryable<T> Find(Expression <Func<T,bool>> expression)
        {
            return _entities.Where(expression);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public T GetByPrimaryKey(object key) {
            return _entities.Find(key);
        }
    }
}
