using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            builder.HasOne(o => o.DeliveryDetails)
                .WithOne(d => d.Order)
                .HasForeignKey<DeliveryDetails>(d => d.OrderId);

            builder.HasMany(o => o.Pizzas)
                .WithOne(d => d.Order)
                .HasForeignKey(p => p.OrderId)
                .IsRequired();
        }
    }
}
