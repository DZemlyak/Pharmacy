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
    public class OrderMap: EntityTypeConfiguration<Core.Order>
    {
        public OrderMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.OrderDate).IsRequired();
            Property(m => m.PharmacyId).IsRequired();
            Property(m => m.Type).IsRequired();
            ToTable("Order");

            HasRequired(m=>m.Pharmacy).WithMany(m=>m.Orders).HasForeignKey(m=>m.PharmacyId).WillCascadeOnDelete(true);
        }
    }
}
