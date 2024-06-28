using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration;

public class FlavorConfiguration : IEntityTypeConfiguration<Flavor>
{
    public void Configure(EntityTypeBuilder<Flavor> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Price).HasPrecision(10, 2);

        builder.HasData(
            new Flavor(1, "3 Queijos", 50.00m),
            new Flavor(2, "Frango com requeijão", 59.99m),
            new Flavor(3, "Mussarela", 42.50m),
            new Flavor(4, "Calabresa", 42.50m),
            new Flavor(5, "Pepperoni", 55.00m),
            new Flavor(6, "Portuguesa", 45.00m),
            new Flavor(7, "Veggie", 59.99m)
        );
    }
}
