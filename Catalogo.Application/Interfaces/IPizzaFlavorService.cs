using Catalogo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Interfaces;

public interface IPizzaFlavorService
{
    Task<IEnumerable<PizzaFlavorDTO>> GetPizzaFlavorsByPizzaId(int? pizzaId);
    Task Add(PizzaFlavorDTO pizzaFlavorDto);
}
