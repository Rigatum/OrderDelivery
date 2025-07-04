using OrderDelivery.Models;

namespace OrderDelivery.DataAccessLayer.Repositories;

public interface IOrderRepository: IGenericRepository<Order>
{
    Task<bool> IsExistOrderNumber(string orderNumber);
}