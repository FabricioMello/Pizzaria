using System;

namespace Catalogo.Domain.Entities
{
    public class PizzaFlavor
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int FlavorId { get; set; }
        public Flavor Flavor { get; set; }
    }
}
