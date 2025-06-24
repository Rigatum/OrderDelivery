using OrderDelivery.DataAccessLayer.Context;
using OrderDelivery.DataAccessLayer.Repositories;
using OrderDelivery.Models;

namespace OrderDelivery.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrderDeliveryDbContext _context;
    private bool _disposed;

    public UnitOfWork(OrderDeliveryDbContext context)
    {
        _context = context;
    }

    public IOrderRepository Orders => 
        new OrderRepository(_context);

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}