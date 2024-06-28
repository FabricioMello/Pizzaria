using Catalogo.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Catalogo.Domain.Tests
{
    public class OrderUnitTest1
    {
        [Fact(DisplayName = "Create Order With Valid State")]
        public void CreateOrder_WithValidParameters_ResultObjectValidState()
        {
            List<Flavor> listFlavor = new List<Flavor>
            {
                new Flavor("Mussarela", 22.5m)
                , new Flavor("calabresa", 25.5m)
            };

            List<Pizza> pizzas = new List<Pizza> { new Pizza(listFlavor) };
            DeliveryDetails deliveryDetails = new DeliveryDetails("Fabrício", "rua pascoal filippi", "47996933146", "400", "Vila Nova");

            Action action = () => new Order(pizzas, deliveryDetails);
            action.Should()
                 .NotThrow<Catalogo.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Order With 0 Pizzas")]
        public void CreateOrder_NoPizzas_ExceptionDomainPizzasNull()
        {
            List<Flavor> listFlavor = new List<Flavor>
            {
                new Flavor("Mussarela", 22.5m)
                , new Flavor("calabresa", 25.5m)
            };

            List<Pizza> pizzas = new List<Pizza>();

            DeliveryDetails deliveryDetails = new DeliveryDetails("Fabrício", "rua pascoal filippi", "47996933146", "400", "Vila Nova");

            Action action = () => new Order(pizzas, deliveryDetails);
            action.Should()
                 .Throw<Catalogo.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Nenhuma pizza selecionada no cardápio.");
        }

        [Fact(DisplayName = "Create Order With 11 Pizzas")]
        public void CreateOrder_ElevenPizzas_ExceptionDomainPizzasAboveTheLimit()
        {
            List<Flavor> listFlavor = new List<Flavor>
            {
                new Flavor("Mussarela", 22.5m)
                , new Flavor("calabresa", 25.5m)
            };

            List<Pizza> pizzas = new List<Pizza>
            {
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor),
                new Pizza(listFlavor)
            };
            DeliveryDetails deliveryDetails = new DeliveryDetails("Fabrício", "rua pascoal filippi", "47996933146", "400", "Vila Nova");

            Action action = () => new Order(pizzas, deliveryDetails);
            action.Should()
                 .Throw<Catalogo.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Número máximo de pizzas excedido por pedido.");
        }
    }
}
