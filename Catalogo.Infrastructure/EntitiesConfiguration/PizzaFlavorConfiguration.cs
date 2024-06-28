using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class PizzaFlavorConfiguration : IEntityTypeConfiguration<PizzaFlavor>
    {
        public void Configure(EntityTypeBuilder<PizzaFlavor> builder)
        {
            builder.HasKey(pf => new { pf.PizzaId, pf.FlavorId });

            builder.HasOne(pf => pf.Pizza)
                .WithMany()
                .HasForeignKey(pf => pf.PizzaId);

            builder.HasOne(pf => pf.Flavor)
                .WithMany()
                .HasForeignKey(pf => pf.FlavorId);
        }
    }
}
