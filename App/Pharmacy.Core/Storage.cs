using Pharmacy.Contracts.Entities;

namespace Pharmacy.Core
{
    public class Storage : IDbEntity
    {
        public int MedcineId { get; set; }
        public int  PharmacyId { get; set; }
        public int  Count { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual Medcine Medcine { get; set; }

    }
}
