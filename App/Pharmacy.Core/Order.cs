using System;
using System.Collections.Generic;

namespace Pharmacy.Core
{
    public class Order:BaseEntity
    {
        public int  PharmacyId { get; set; }
        public OperationType Type { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderDetails> OrderDetailses { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }

        public Order()
        {
            OrderDetailses = new List<OrderDetails>();
        }
    }
}
