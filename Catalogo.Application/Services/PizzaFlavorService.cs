using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Services;

public class PizzaFlavorService : IPizzaFlavorService
{
    private IPizzaFlavorRepository _pizzaFlavorRepository;

    private readonly IMapper _mapper;
    public PizzaFlavorService(IMapper mapper, IPizzaFlavorRepository pizzaFlavorRepository)
    {
        _pizzaFlavorRepository = pizzaFlavorRepository ??
             throw new ArgumentNullException(nameof(pizzaFlavorRepository));

        _mapper = mapper;
    }

    public async Task<IEnumerable<PizzaFlavorDTO>> GetPizzaFlavorsByPizzaId(int? pizzaId)
    {
        var pizzaFlavorsEntity = await _pizzaFlavorRepository.GetPizzaFlavorsByPizzaIdAsync(pizzaId);
        return _mapper.Map<IEnumerable<PizzaFlavorDTO>>(pizzaFlavorsEntity);
    }

    public async Task Add(PizzaFlavorDTO pizzaFlavorDto)
    {
        var pizzaFlavorEntity = _mapper.Map<PizzaFlavor>(pizzaFlavorDto);
        await _pizzaFlavorRepository.CreateAsync(pizzaFlavorEntity);
    }
}
