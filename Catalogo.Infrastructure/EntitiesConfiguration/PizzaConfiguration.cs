using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration;

public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Price).HasPrecision(10, 2).IsRequired();

        builder.HasOne(e => e.Order).WithMany(e => e.Pizzas)
            .HasForeignKey(e => e.OrderId);
    }
}
