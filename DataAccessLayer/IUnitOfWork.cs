using OrderDelivery.DataAccessLayer.Repositories;

namespace OrderDelivery.DataAccessLayer;

public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }

    Task<bool> SaveChangesAsync();
}