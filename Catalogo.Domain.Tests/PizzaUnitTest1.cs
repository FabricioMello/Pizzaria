using Catalogo.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Catalogo.Domain.Tests
{
    public class PizzaUnitTest1
    {
        [Fact(DisplayName = "Create Pizza With Valid State")]
        public void CreatePizza_WithValidParameters_ResultObjectValidState()
        {
            List<Flavor> listFlavor = new List<Flavor>
            { 
                new Flavor("Mussarela", 22.5m)
                , new Flavor("calabresa", 25.5m) 
            };

            Action action = () => new Pizza(listFlavor);
            action.Should()
                 .NotThrow<Catalogo.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Pizza With Flavors Incorrect")]
        public void CreatePizza_InvalidPrice_ResultObjectValidState()
        {
            List<Flavor> listFlavor = new List<Flavor>
            {
                new Flavor("Mussarela", 22.5m)
                , new Flavor("calabresa", 25.5m)
                , new Flavor("Chocolate", 30.0m)
            };

            Action action = () => new Pizza(listFlavor);
            action.Should()
                 .Throw<Catalogo.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("A quantidade máxima de sabores por pizza é 2");
        }

    }
}
