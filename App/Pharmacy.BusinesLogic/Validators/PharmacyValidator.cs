using System;
using System.Linq;
using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;

namespace Pharmacy.BusinesLogic.Validators
{
    public class PharmacyValidator : IValidator<Core.Pharmacy>
    {
        private readonly IRepository<Core.Pharmacy> _repository;

        public PharmacyValidator(IRepository<Core.Pharmacy> repository) {
            _repository = repository;
        }

        public bool IsValid(Core.Pharmacy entity) {
            var validity = !String.IsNullOrEmpty(entity.Address)
                   && !String.IsNullOrEmpty(entity.PhoneNumber)
                   && entity.Number > 0;

            foreach (var pharmacy in _repository.GetAll().ToList()) {
                if (!validity) break;
                if (pharmacy.Address == entity.Address
                    && pharmacy.PhoneNumber == entity.PhoneNumber
                    && pharmacy.Number == entity.Number)
                    validity = false;
            }

            return validity;
        }

        public bool IsExists(object key) {
            return _repository.GetByPrimaryKey(key) != null;
        }
    }
}
