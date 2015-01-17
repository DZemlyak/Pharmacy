using Pharmacy.Contracts.Entities;

namespace Pharmacy.Contracts.Validator
{
    public interface IValidator<T> where T : class, IDbEntity
    {
        bool IsValid(T entity);
        bool IsExists(object key);
    }
}
