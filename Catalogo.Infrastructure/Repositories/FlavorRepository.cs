using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories;

public class FlavorRepository : IFlavorRepository
{
    private ApplicationDbContext _productContext;
    public FlavorRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }

    public async Task<Flavor> CreateAsync(Flavor product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Flavor> GetByIdAsync(int? id)
    {
        return await _productContext.Flavors
           .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Flavor> RemoveAsync(Flavor product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}
