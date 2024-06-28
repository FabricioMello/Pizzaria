using Catalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    public interface IPizzaFlavorRepository
    {
        Task<IEnumerable<PizzaFlavor>> GetPizzaFlavorsByPizzaIdAsync(int? pizzaId);
        Task<PizzaFlavor> CreateAsync(PizzaFlavor product);
        Task<PizzaFlavor> RemoveAsync(PizzaFlavor product);
    }
}
