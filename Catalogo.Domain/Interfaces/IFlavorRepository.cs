using Catalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    public interface IFlavorRepository
    {
        Task<Flavor> GetByIdAsync(int? id);
        Task<Flavor> CreateAsync(Flavor product);
        Task<Flavor> RemoveAsync(Flavor product);
    }
}
