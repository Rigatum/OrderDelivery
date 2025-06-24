using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrderDelivery.DataAccessLayer;
using OrderDelivery.Models.ViewModels;
using OrderDelivery.Services;

namespace OrderDelivery.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;
    private readonly IUnitOfWork _unitOfWork;

    public OrderController(ILogger<OrderController> logger, IOrderService orderService,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _orderService = orderService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var indexVM = await _orderService.InitIndexVMAsync();

        return View(indexVM);
    }

    public async Task<IActionResult> Create()
    {
        var orderVM = new OrderVM();
        orderVM.OrderNumber = await _orderService.GetOrderNumberAsync();

        return View(orderVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderVM createOrderVM)
    {
        if (ModelState.IsValid)
        {
            await _orderService.CreateOrderAsync(createOrderVM);

            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(createOrderVM);
    }

    [HttpGet]
    public async Task<IActionResult> OrderDetails(Guid id)
    {
        try
        {
            var order = await _orderService.GetOrderAsync(id);

            return View(order);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении деталей заказа");
            return StatusCode(500);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
