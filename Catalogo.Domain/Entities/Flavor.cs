using Catalogo.Domain.Entities;
using Catalogo.Domain.Validation;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities;
public sealed class Flavor : Entity
{
    private Flavor() { }

    public Flavor(string name, decimal price)
    {
        ValidateDomain(name, price);
    }

    public Flavor(int id, string name, decimal price)
    {
        DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
        Id = id;
        ValidateDomain(name, price);
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public void ValidateDomain(string name, decimal price)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(name.Length < 3,
            "O nome do sabor deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(price < 21, "Valor do sabor inválido");

        Name = name;
        Price = price;
    }
    public ICollection<PizzaFlavor> PizzaFlavors { get; set; }
}