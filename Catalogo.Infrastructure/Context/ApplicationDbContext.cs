using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Catalogo.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<DeliveryDetails> DeliverysDetails { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<PizzaFlavor> PizzasFlavors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
        .Assembly);

        builder.Entity<PizzaFlavor>()
        .HasOne(pf => pf.Pizza)
        .WithMany(p => p.PizzaFlavors)
        .HasForeignKey(pf => pf.PizzaId);

        builder.Entity<PizzaFlavor>()
            .HasOne(pf => pf.Flavor)
            .WithMany(f => f.PizzaFlavors)
            .HasForeignKey(pf => pf.FlavorId);
    }
}
