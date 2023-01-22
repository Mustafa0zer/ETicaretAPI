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
    public class CompanyConfigurations:BaseConfigurations<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x=>x.Name).HasMaxLength(80);
            builder.HasMany(x => x.Orders).WithOne(o => o.MyCompany).HasForeignKey(o => o.CompanyID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
