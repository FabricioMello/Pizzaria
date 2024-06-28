using Catalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    public interface IPizzaRepository
    {
        Task<IEnumerable<Pizza>> GetPizzasByOrderIdAsync(int? orderId);
        Task<Pizza> GetByIdAsync(int? id);
        Task<Pizza> CreateAsync(Pizza product);
        Task<Pizza> RemoveAsync(Pizza product);
    }
}
