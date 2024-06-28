using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories;

public class DeliveryDetailsRepository : IDeliveryDetailsRepository
{
    private ApplicationDbContext _productContext;
    public DeliveryDetailsRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }

    public async Task<DeliveryDetails> CreateAsync(DeliveryDetails product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<DeliveryDetails> GetByOrderIdAsync(int? orderId)
    {
        return await _productContext.DeliverysDetails.Include(c => c.Order)
           .SingleOrDefaultAsync(p => p.OrderId == orderId);
    }

    public async Task<DeliveryDetails> RemoveAsync(DeliveryDetails product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}
