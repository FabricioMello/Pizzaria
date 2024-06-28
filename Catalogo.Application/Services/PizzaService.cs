using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Services;

public class PizzaService : IPizzaService
{
    private IPizzaRepository _pizzaRepository;

    private readonly IMapper _mapper;
    public PizzaService(IMapper mapper, IPizzaRepository pizzaRepository)
    {
        _pizzaRepository = pizzaRepository ??
             throw new ArgumentNullException(nameof(pizzaRepository));

        _mapper = mapper;
    }

    public async Task<IEnumerable<PizzaDTO>> GetPizzasByOrderId(int? orderId)
    {
        var pizzasEntity = await _pizzaRepository.GetPizzasByOrderIdAsync(orderId);
        return _mapper.Map<IEnumerable<PizzaDTO>>(pizzasEntity);
    }

    public async Task<PizzaDTO> GetById(int? id)
    {
        var pizzaEntity = await _pizzaRepository.GetByIdAsync(id);
        return _mapper.Map<PizzaDTO>(pizzaEntity);
    }

    public async Task Add(PizzaDTO pizzaDto)
    {
        var pizzaEntity = _mapper.Map<Pizza>(pizzaDto);
        await _pizzaRepository.CreateAsync(pizzaEntity);
    }

    public async Task Remove(int? id)
    {
        var pizzaEntity = _pizzaRepository.GetByIdAsync(id).Result;
        await _pizzaRepository.RemoveAsync(pizzaEntity);
    }
}
