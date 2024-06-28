using Catalogo.Application.DTOs;
using System.Threading.Tasks;

namespace Catalogo.Application.Interfaces;

public interface IFlavorService
{
    Task<FlavorDTO> GetById(int? id);
    Task Add(FlavorDTO flavorDto);
    Task Remove(int? id);
}
