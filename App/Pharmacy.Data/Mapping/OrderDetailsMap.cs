using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Pharmacy.Core;

namespace Pharmacy.Data.Mapping
{
    public class OrderDetailsMap : EntityTypeConfiguration<Core.OrderDetails>
    {
        public OrderDetailsMap()
        {
            HasKey(s => new { s.OrderId, s.MedcineId});
            Property(m => m.Count).IsRequired();

            ToTable("OrderDetails");

            HasRequired(m=>m.Medcine).WithMany(m=>m.OrderDetailses).HasForeignKey(m=>m.MedcineId).WillCascadeOnDelete(true);
            HasRequired(m => m.Order).WithMany(m => m.OrderDetailses).HasForeignKey(m => m.OrderId).WillCascadeOnDelete(true);
        }
    }
}
