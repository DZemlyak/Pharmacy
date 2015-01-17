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
    public class MedcineMap: EntityTypeConfiguration<Medcine>
    {
        public MedcineMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Description).IsRequired();
            Property(m => m.Name).IsRequired();
            Property(m => m.SerialNumber).IsRequired();

            ToTable("Medcine");
        }
    }
}
