using OrderDelivery.Models.ViewModels;

namespace OrderDelivery.Services;

public interface IOrderService
{
    CreateOrderVM InitOrderCreateVM();
    Task<CreateOrderVM> CreateOrder(CreateOrderVM createOrderVM);
}
