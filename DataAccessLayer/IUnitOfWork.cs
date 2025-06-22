using OrderDelivery.DataAccessLayer.Repositories;
using OrderDelivery.Models;

namespace OrderDelivery.DataAccessLayer;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Order> Orders { get; }

    Task<bool> SaveChangesAsync();
}