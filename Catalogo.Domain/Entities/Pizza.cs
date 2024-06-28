using Catalogo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Domain.Entities;

public sealed class Pizza : Entity
{
    private Pizza() { }

    public Pizza(List<Flavor> flavors)
    {
        ValidateDomain(flavors);
        Price = calculatePrice();
    }

    public List<Flavor> Flavors { get; private set; } = new List<Flavor>();
    public decimal Price { get; }

    private decimal calculatePrice()
    {
        return Flavors.Sum(x => x.Price) / Flavors.Count;
    }

    private void ValidateDomain(List<Flavor> flavors)
    {
        DomainExceptionValidation.When(flavors?.Count < 1,
            "A quantidade mínima de sabor por pizza é 1");

        DomainExceptionValidation.When(flavors?.Count > 2,
            "A quantidade máxima de sabores por pizza é 2");

        Flavors = flavors;
    }

    public int OrderId { get; set; }
    public Order Order { get; set; }
    public ICollection<PizzaFlavor> PizzaFlavors { get; set; }
}
