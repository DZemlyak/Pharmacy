using Pharmacy.Contracts.Entities;

namespace Pharmacy.Core
{
    public class OrderDetails : IDbEntity
    {
        public int OrderId { get; set; }
        public int MedcineId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
        
        public virtual Order Order { get; set; }
        public virtual Medcine Medcine { get; set; }
    }
}
