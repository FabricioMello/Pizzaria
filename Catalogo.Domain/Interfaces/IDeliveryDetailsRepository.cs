using Catalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    public interface IDeliveryDetailsRepository
    {
        Task<DeliveryDetails> GetByOrderIdAsync(int? id);
        Task<DeliveryDetails> CreateAsync(DeliveryDetails deliveryDetails);
        Task<DeliveryDetails> RemoveAsync(DeliveryDetails deliveryDetails);
    }
}
