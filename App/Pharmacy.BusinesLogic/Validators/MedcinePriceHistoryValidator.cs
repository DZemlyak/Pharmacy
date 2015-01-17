using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;
using Pharmacy.Core;

namespace Pharmacy.BusinesLogic.Validators
{
    public class MedcinePriceHistoryValidator : IValidator<MedcinePriceHistory>
    {
        private readonly IRepository<MedcinePriceHistory> _historyRepository;
        private readonly IValidator<Medcine> _medcineValidator;

        public MedcinePriceHistoryValidator(IRepository<MedcinePriceHistory> historyRepository,
            IValidator<Medcine> medcineValidator) {
            _historyRepository = historyRepository;
            _medcineValidator = medcineValidator;
        }

        public bool IsValid(MedcinePriceHistory entity) {
            return _medcineValidator.IsExists(entity.MedcineId)
                   && entity.Price > 0
                   && entity.MedcineId == entity.Medcine.Id;
        }

        public bool IsExists(object key) {
            return _historyRepository.GetByPrimaryKey(key) != null;
        }
    }
}
