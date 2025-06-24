using OrderDelivery.Models.ViewModels;

namespace OrderDelivery.Services;

public interface IOrderService
{
    Task<IndexVM> InitIndexVMAsync();
    Task<OrderVM> CreateOrderAsync(OrderVM createOrderVM);
    Task<OrderVM> GetOrderAsync(Guid id);
    Task<string> GetOrderNumberAsync();
}
