using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DeliveryConfiguration : IEntityTypeConfiguration<DeliveryModel>
{
    public void Configure(EntityTypeBuilder<DeliveryModel> builder)
    {
        builder.HasKey(d => d.id);
       
    }
}