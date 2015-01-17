using Microsoft.Practices.Unity;
using Pharmacy.BusinesLogic.Validators;
using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;
using Pharmacy.Core;
using Pharmacy.Data;

namespace Pharmacy.BusinesLogic.Unity
{
    public static class Container
    {
        public static readonly IUnityContainer UnityContainer;

        static Container() {
            UnityContainer = new UnityContainer();
            UnityContainer
                .RegisterType(typeof (IRepository<>), typeof (Repository<>))
                .RegisterType<DataContext>(new ContainerControlledLifetimeManager())
                .RegisterType(typeof (IValidator<MedcinePriceHistory>), typeof (MedcinePriceHistoryValidator))
                .RegisterType(typeof (IValidator<Medcine>), typeof (MedcineValidator))
                .RegisterType(typeof (IValidator<OrderDetails>), typeof (OrderDetailsValidator))
                .RegisterType(typeof (IValidator<Core.Pharmacy>), typeof (PharmacyValidator))
                .RegisterType(typeof (IValidator<Storage>), typeof (StorageValidator));
        }
    }
}
