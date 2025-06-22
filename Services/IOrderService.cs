using OrderDelivery.Models.ViewModels;

namespace OrderDelivery.Services;

public interface IOrderService
{
    Task<CreateOrderVM> InitOrderCreateVM();
    Task<CreateOrderVM> CreateOrder(CreateOrderVM createOrderVM);
}
