using Catalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int? id);
        Task<Order> CreateAsync(Order categoria);
        Task<Order> RemoveAsync(Order categoria);
    }
}
