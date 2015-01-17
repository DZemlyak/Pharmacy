using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;
using Pharmacy.Core;

namespace Pharmacy.BusinesLogic.Validators
{
    public class OrderDetailsValidator : IValidator<OrderDetails>
    {
        private readonly IRepository<OrderDetails> _repository;
        private readonly IValidator<Order> _orderValidator;
        private readonly IValidator<Medcine> _medcineValidator; 

        public OrderDetailsValidator(IRepository<OrderDetails> repository, 
            IValidator<Order> orderValidator, 
            IValidator<Medcine> medcineValidator)
        {
            _repository = repository;
            _orderValidator = orderValidator;
            _medcineValidator = medcineValidator;
        }

        public bool IsValid(OrderDetails entity) {
            return _orderValidator.IsExists(entity.OrderId)
                   && _medcineValidator.IsExists(entity.MedcineId)
                   && entity.MedcineId == entity.Medcine.Id
                   && entity.OrderId == entity.Order.Id
                   && entity.UnitPrice > 0
                   && entity.Count > 0;
        }

        public bool IsExists(object key) {
            return _repository.GetByPrimaryKey(key) != null;
        }
    }
}
