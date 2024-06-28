using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Services;

public class OrderService : IOrderService
{
    private IOrderRepository _orderRepository;
    private IFlavorRepository _flavorRepository;
    private IPizzaFlavorRepository _pizzaFlavorRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository,
        IFlavorRepository flavorRepository,
        IPizzaFlavorRepository pizzaFlavorRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _flavorRepository = flavorRepository;
        _pizzaFlavorRepository = pizzaFlavorRepository;
        _mapper = mapper;
    }


    public async Task<OrderDTO> GetById(int? id)
    {
        var orderEntity = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDTO>(orderEntity);
    }

    public async Task<int> Add(OrderDTO orderDto)
    {
        var pizzas = new List<Pizza>();
        foreach (var pizzaDto in orderDto.Pizzas)
        {
            var flavors = new List<Flavor>();
            foreach (var flavorDto in pizzaDto.Flavors)
            {
                var flavorEntity = await _flavorRepository.GetByIdAsync(flavorDto.Id);
                if (flavorEntity != null)
                {
                    flavors.Add(flavorEntity);
                }
            }
            var pizzaEntity = new Pizza(flavors);
            pizzas.Add(pizzaEntity);
        }

        DeliveryDetails deliveryDetails = new DeliveryDetails(
            orderDto.DeliveryDetails.Name,
            orderDto.DeliveryDetails.Address,
            orderDto.DeliveryDetails.PhoneNumber,
            orderDto.DeliveryDetails.HouseNumber,
            orderDto.DeliveryDetails.District
        );

        Order orderEntity = new Order(pizzas, deliveryDetails);
        //var orderEntity = _mapper.Map<Order>(orderDto);
        Order result = await _orderRepository.CreateAsync(orderEntity);

        foreach (Pizza pizza in result.Pizzas) 
        { 
            foreach (Flavor flavor in pizza.Flavors)
            {
                PizzaFlavor pizzaFlavor = new PizzaFlavor();
                pizzaFlavor.PizzaId = pizza.Id;
                pizzaFlavor.FlavorId = flavor.Id;
                await _pizzaFlavorRepository.CreateAsync(pizzaFlavor);
            }
        }


        return result.Id;
    }

    public async Task Remove(int? id)
    {
        var orderEntity = _orderRepository.GetByIdAsync(id).Result;
        await _orderRepository.RemoveAsync(orderEntity);
    }
}
