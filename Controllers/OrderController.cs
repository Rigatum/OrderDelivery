using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrderDelivery.Models.ViewModels;
using OrderDelivery.Services;

namespace OrderDelivery.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        var orderCreateVM = await _orderService.InitOrderCreateVM();

        return View(orderCreateVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrderVM createOrderVM)
    {
        if (ModelState.IsValid)
        {
            await _orderService.CreateOrder(createOrderVM);

            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
