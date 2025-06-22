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

    public CreateOrderVM InitOrderCreateVM()
    {
        var createOrderVM = new CreateOrderVM();

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

        await _unitOfWork.Orders.AddAsync(order);

        return createOrderVM;
    }
}