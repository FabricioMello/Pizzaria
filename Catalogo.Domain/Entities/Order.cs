using Catalogo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Domain.Entities;

public sealed class Order : Entity
{
    private Order() { }

    
    public Order(ICollection<Pizza> pizzas, DeliveryDetails deliveryDetails)
    {
        ValidateDomain(pizzas);

        Id = GerarIdPedido();
        DeliveryDetails = deliveryDetails;
        Pizzas = pizzas.ToList();
        TotalPrice = CalculateTotalPrice();
        RequestDate = DateTime.UtcNow;
    }

    public List<Pizza> Pizzas { get; private set; } = new List<Pizza>();
    public DeliveryDetails DeliveryDetails { get; private set; }
    public decimal TotalPrice { get; private set; }
    public DateTime RequestDate { get; private set; }

    private void ValidateDomain(ICollection<Pizza> pizzas)
    {
        DomainExceptionValidation.When(pizzas.Count() < 1,
            "Nenhuma pizza selecionada no cardápio.");

        DomainExceptionValidation.When(pizzas.Count() > 10,
            "Número máximo de pizzas excedido por pedido.");
    }

    private decimal CalculateTotalPrice()
    {
        return Pizzas.Sum(p => p.Price);
    }

    public int GerarIdPedido()
    {
        var now = DateTime.Now;
        var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
        int uniqueId = (int)(zeroDate.Ticks / 10000);
        return uniqueId;
    }
}
