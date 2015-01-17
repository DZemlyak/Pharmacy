using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Pharmacy.Core;

namespace Pharmacy.Data.Mapping
{
    public class StorageMap: EntityTypeConfiguration<Core.Storage>
    {
        public StorageMap()
        {
            HasKey(s => new { s.MedcineId , s.PharmacyId });
            Property(m => m.Count).IsRequired();
            ToTable("Storage");
            HasRequired(m => m.Pharmacy).WithMany(m => m.Storages).HasForeignKey(m => m.PharmacyId).WillCascadeOnDelete(true);
            HasRequired(m => m.Medcine).WithMany(m => m.Storages).HasForeignKey(m => m.MedcineId).WillCascadeOnDelete(true);
        }
    }
}
