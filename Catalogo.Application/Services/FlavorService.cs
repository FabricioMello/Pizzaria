using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Services;

public class FlavorService : IFlavorService
{
    private IFlavorRepository _flavorRepository;

    private readonly IMapper _mapper;
    public FlavorService(IMapper mapper, IFlavorRepository flavorRepository)
    {
        _flavorRepository = flavorRepository ??
             throw new ArgumentNullException(nameof(flavorRepository));

        _mapper = mapper;
    }

    public async Task<FlavorDTO> GetById(int? id)
    {
        var flavorEntity = await _flavorRepository.GetByIdAsync(id);
        return _mapper.Map<FlavorDTO>(flavorEntity);
    }

    public async Task Add(FlavorDTO flavorDto)
    {
        var flavorEntity = _mapper.Map<Flavor>(flavorDto);
        await _flavorRepository.CreateAsync(flavorEntity);
    }

    public async Task Remove(int? id)
    {
        var flavorEntity = _flavorRepository.GetByIdAsync(id).Result;
        await _flavorRepository.RemoveAsync(flavorEntity);
    }
}
