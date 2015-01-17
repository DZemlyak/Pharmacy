using System;
using System.Collections.Generic;

namespace Pharmacy.Core
{
    public class Pharmacy : BaseEntity
    {
        public string Address { get; set; }
        public int Number { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OpenDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Storage> Storages{ get; set; }
        

        public Pharmacy()
        {
            Orders = new List<Order>();
            Storages = new List<Storage>();
        }
    }
}
