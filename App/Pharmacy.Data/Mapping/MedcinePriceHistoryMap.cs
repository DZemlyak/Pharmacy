using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Pharmacy.Core;

namespace Pharmacy.Data.Mapping
{
    public class MedcinePriceHistoryMap: EntityTypeConfiguration<Core.MedcinePriceHistory>
    {
        public MedcinePriceHistoryMap()
        {
            HasKey(m => m.Id);
            Property(m => m.MedcineId).IsRequired();
            Property(m => m.Price).IsRequired();
            Property(m => m.PriceDate).IsRequired();
            ToTable("MedcinePriceHistory");

            HasRequired(m => m.Medcine).WithMany(m => m.MedcinePriceHistories).HasForeignKey(m => m.MedcineId).WillCascadeOnDelete(true);
        }
    }
}
