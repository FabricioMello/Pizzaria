using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Domain.Entities;

namespace Catalogo.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<Pizza, PizzaDTO>().ReverseMap();
        CreateMap<DeliveryDetails, DeliveryDetailsDTO>().ReverseMap();
        CreateMap<Flavor, FlavorDTO>().ReverseMap();
        CreateMap<PizzaFlavor, PizzaFlavorDTO>().ReverseMap();
    }
}
