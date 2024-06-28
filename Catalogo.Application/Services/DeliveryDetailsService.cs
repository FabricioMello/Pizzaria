using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Services;

public class DeliveryDetailsService : IDeliveryDetailsService
{
    private IDeliveryDetailsRepository _deliveryDetailsRepository;

    private readonly IMapper _mapper;
    public DeliveryDetailsService(IMapper mapper, IDeliveryDetailsRepository deliveryDetailsRepository)
    {
        _deliveryDetailsRepository = deliveryDetailsRepository ??
             throw new ArgumentNullException(nameof(deliveryDetailsRepository));

        _mapper = mapper;
    }

    public async Task<DeliveryDetailsDTO> GetDeliveryDetailsByOrderId(int? orderId)
    {
        var deliveryDetailsEntity = await _deliveryDetailsRepository.GetByOrderIdAsync(orderId);
        return _mapper.Map<DeliveryDetailsDTO>(deliveryDetailsEntity);
    }

    public async Task Add(DeliveryDetailsDTO deliveryDetailsDto)
    {
        var deliveryDetailsEntity = _mapper.Map<DeliveryDetails>(deliveryDetailsDto);
        await _deliveryDetailsRepository.CreateAsync(deliveryDetailsEntity);
    }

    public async Task Remove(int? orderId)
    {
        var deliveryDetailsEntity = _deliveryDetailsRepository.GetByOrderIdAsync(orderId).Result;
        await _deliveryDetailsRepository.RemoveAsync(deliveryDetailsEntity);
    }
}
