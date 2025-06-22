using OrderDelivery.DataAccessLayer.Repositories;
using OrderDelivery.Models;
using OrderDelivery.Models.ViewModels;

namespace OrderDelivery.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<CreateOrderVM> InitOrderCreateVM()
    {
        var createOrderVM = new CreateOrderVM();

        var test = await _orderRepository.GetAllAsync();

        return createOrderVM;
    }

    public async Task<CreateOrderVM> CreateOrder(CreateOrderVM createOrderVM)
    {
        var order = new Order()
        {
            OrderNumber = createOrderVM.OrderNumber,
            SenderCity = createOrderVM.SenderCity,
            SenderAddress = createOrderVM.SenderAddress,
            ReceiverCity = createOrderVM.ReceiverCity,
            ReceiverAddress = createOrderVM.ReceiverAddress,
            Weight = createOrderVM.Weight,
            PickupDate = createOrderVM.PickupDate
        };

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        return createOrderVM;
    }
}