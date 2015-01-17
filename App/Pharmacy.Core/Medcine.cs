using System.Collections.Generic;

namespace Pharmacy.Core
{
    public class Medcine:BaseEntity
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual List<Storage> Storages { get; set; }
        public virtual List<MedcinePriceHistory> MedcinePriceHistories { get; set; }
        public virtual List<OrderDetails> OrderDetailses { get; set; }

        public Medcine()
        {
            Storages = new List<Storage>();
            MedcinePriceHistories = new List<MedcinePriceHistory>();
            OrderDetailses = new List<OrderDetails>();
        }
    }
}
