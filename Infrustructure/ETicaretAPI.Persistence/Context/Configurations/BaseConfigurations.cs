using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ETicaretAPI.Persistence.Context.Configurations
{
    public class BaseConfigurations<T>:IEntityTypeConfiguration<T> where T :BaseEntitiy
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.ID).HasConversion(new GuidToStringConverter()).IsRequired();
            builder.HasKey(x => x.ID);

        }
    }
}
