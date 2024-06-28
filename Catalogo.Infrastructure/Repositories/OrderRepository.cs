using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private ApplicationDbContext _orderContext;
    public OrderRepository(ApplicationDbContext context)
    {
        _orderContext = context;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        _orderContext.Add(order);
        await _orderContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order> GetByIdAsync(int? id)
    {
        return await _orderContext.Orders
            .Include(o => o.Pizzas)
                .ThenInclude(p => p.Flavors)
            .Include(o => o.DeliveryDetails)
            .FirstOrDefaultAsync(o => o.Id == id);
    }


    public async Task<Order> RemoveAsync(Order order)
    {
        _orderContext.Remove(order);
        await _orderContext.SaveChangesAsync();
        return order;
    }
}
