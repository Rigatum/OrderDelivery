using OrderDelivery.DataAccessLayer;
using OrderDelivery.Models;
using OrderDelivery.Models.ViewModels;

namespace OrderDelivery.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IndexVM> InitIndexVMAsync()
    {
        var orders = (await _unitOfWork.Orders.GetAllAsync())
            .OrderByDescending(o => o.DateCreated);

        var indexVM = new IndexVM()
        {
            Orders = orders.Select(o => new OrderVM()
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                SenderCity = o.SenderCity,
                SenderAddress = o.SenderAddress,
                ReceiverCity = o.ReceiverCity,
                ReceiverAddress = o.ReceiverAddress,
                Weight = o.Weight,
                PickupDate = o.PickupDate
            })
        };

        return indexVM;
    }

    public async Task<OrderVM> CreateOrderAsync(OrderVM createOrderVM)
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

        await _unitOfWork.Orders.AddAsync(order);

        return createOrderVM;
    }

    public async Task<OrderVM> GetOrderAsync(Guid id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);

        if (order == null)
        {
            throw new Exception("Заказ не найден");
        }

        var orderVM = new OrderVM()
        {
            OrderNumber = order.OrderNumber,
            SenderCity = order.SenderCity,
            SenderAddress = order.SenderAddress,
            ReceiverCity = order.ReceiverCity,
            ReceiverAddress = order.ReceiverAddress,
            Weight = order.Weight,
            PickupDate = order.PickupDate
        };

        return orderVM;
    }
}