using Catalogo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Interfaces;

public interface IOrderService
{
    Task<OrderDTO> GetById(int? id);
    Task<int> Add(OrderDTO orderDto);
    Task Remove(int? id);
}
