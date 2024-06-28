using Catalogo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Interfaces;

public interface IDeliveryDetailsService
{
    Task<DeliveryDetailsDTO> GetDeliveryDetailsByOrderId(int? orderId);
    Task Add(DeliveryDetailsDTO pizzaDto);
    Task Remove(int? orderId);
}
