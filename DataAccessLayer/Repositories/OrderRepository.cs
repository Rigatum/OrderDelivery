using Microsoft.EntityFrameworkCore;
using OrderDelivery.DataAccessLayer.Context;
using OrderDelivery.Models;

namespace OrderDelivery.DataAccessLayer.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(OrderDeliveryDbContext context) : base(context)
    {

    }

    public async Task<bool> IsExistOrderNumber(string orderNumber) =>
        await _dbSet.AnyAsync(o => o.OrderNumber == orderNumber);
}
