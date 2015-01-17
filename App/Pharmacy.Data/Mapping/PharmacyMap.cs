using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Pharmacy.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Mapping
{
    public class PharmacyMap: EntityTypeConfiguration<Core.Pharmacy>
    {
        public PharmacyMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Number).IsRequired();
            Property(m => m.OpenDate).IsRequired();
            Property(m => m.PhoneNumber).IsRequired();
            Property(m => m.Address).IsRequired();
            ToTable("Pharmacy");
        }
    }
}
