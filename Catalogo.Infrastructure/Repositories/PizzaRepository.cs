using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private ApplicationDbContext _productContext;
    public PizzaRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }

    public async Task<IEnumerable<Pizza>> GetPizzasByOrderIdAsync(int? orderId)
    {
        return await _productContext.Pizzas
        .Where(p => p.OrderId == orderId)
        .ToListAsync();
    }

    public async Task<Pizza> CreateAsync(Pizza product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Pizza> GetByIdAsync(int? id)
    {
        return await _productContext.Pizzas.Include(c => c.Order)
           .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pizza> RemoveAsync(Pizza product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}
