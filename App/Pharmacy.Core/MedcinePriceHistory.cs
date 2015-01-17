using System;

namespace Pharmacy.Core
{
    public class MedcinePriceHistory : BaseEntity
    {
        public int  MedcineId { get; set; }
        public decimal Price { get; set; }
        public DateTime PriceDate { get; set; }

        public virtual Medcine Medcine { get; set; }

        public MedcinePriceHistory()
        {
        }
    }
}
