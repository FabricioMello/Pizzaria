using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IDeliveryDetailsService _deliveryDetailsService;
    private readonly IFlavorService _flavorService;
    private readonly IOrderService _orderService;
    private readonly IPizzaFlavorService _pizzaFlavorService;
    private readonly IPizzaService _pizzaService;

    public OrderController(
        IDeliveryDetailsService deliveryDetailsService,
        IFlavorService flavorService,
        IOrderService orderService,
        IPizzaFlavorService pizzaFlavorService,
        IPizzaService pizzaService
        )
    {
        _deliveryDetailsService = deliveryDetailsService;
        _flavorService = flavorService;
        _orderService = orderService;
        _pizzaFlavorService = pizzaFlavorService;
        _pizzaService = pizzaService;
    }

    [HttpGet("{id}", Name = "GetOrder")]
    public async Task<ActionResult<Order>> Get(int id)
    {
        var order = await _orderService.GetById(id);

        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] OrderDTO orderDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _orderService.Add(orderDto);

        return Ok(await _orderService.GetById(result));
    }
}
