using Catalogo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Interfaces;

public interface IPizzaService
{
    Task<IEnumerable<PizzaDTO>> GetPizzasByOrderId(int? orderId);
    Task<PizzaDTO> GetById(int? id);
    Task Add(PizzaDTO pizzaDto);
    Task Remove(int? id);
}
