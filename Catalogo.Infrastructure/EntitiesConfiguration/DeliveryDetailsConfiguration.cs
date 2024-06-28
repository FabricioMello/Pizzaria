using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class DeliveryDetailsConfiguration : IEntityTypeConfiguration<DeliveryDetails>
    {
        public void Configure(EntityTypeBuilder<DeliveryDetails> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(200).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(p => p.HouseNumber).HasMaxLength(7);
            builder.Property(p => p.District).HasMaxLength(50);

            builder.HasOne(d => d.Order)
                .WithOne(o => o.DeliveryDetails)
                .HasForeignKey<DeliveryDetails>(d => d.OrderId);
        }
    }
}
