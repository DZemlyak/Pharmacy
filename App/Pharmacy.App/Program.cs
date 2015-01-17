using System;
using Microsoft.Practices.Unity;
using Pharmacy.BusinesLogic.Manager;
using Pharmacy.BusinesLogic.Unity;
using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;

namespace Pharmacy.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = Container.UnityContainer.Resolve<IRepository<Core.Pharmacy>>();
            var validator = Container.UnityContainer.Resolve<IValidator<Core.Pharmacy>>();
            var manager = new Manager<Core.Pharmacy>(repository, validator);
            manager.Add(new Core.Pharmacy() {
                Address = "Lviv",
                Number = 5,
                PhoneNumber = "093 000 00 00",
                OpenDate = DateTime.Now.AddDays(-15),
            });
            foreach (var p in manager.GetAll())
            {
                Console.WriteLine(p.Address);
            }
        }
    }
}
