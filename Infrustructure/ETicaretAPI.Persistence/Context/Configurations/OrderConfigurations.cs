using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Context.Configurations
{
    public class OrderConfigurations:BaseConfigurations<Order>
    {
        public virtual void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.OrderOwner).IsRequired().HasMaxLength(80);
            builder.HasOne(x => x.MyCompany).WithMany(c => c.Orders).HasForeignKey(x=>x.CompanyID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Products).WithMany(p => p.Orders);


        }
    }
}
