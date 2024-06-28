using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories;

public class PizzaFlavorRepository : IPizzaFlavorRepository
{
    private ApplicationDbContext _productContext;
    public PizzaFlavorRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }

    public async Task<PizzaFlavor> CreateAsync(PizzaFlavor product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<PizzaFlavor>> GetPizzaFlavorsByPizzaIdAsync(int? pizzaId)
    {
        return await _productContext.PizzasFlavors
           .Where(pf => pf.PizzaId == pizzaId)
           .ToListAsync();
    }

    public async Task<PizzaFlavor> RemoveAsync(PizzaFlavor product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}
