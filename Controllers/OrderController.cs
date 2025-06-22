using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrderDelivery.DataAccessLayer.Repositories;
using OrderDelivery.Models;

namespace OrderDelivery.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderRepository _orderRepository;

    public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository)
    {
        _logger = logger;
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> Index()
    {
        var test = await _orderRepository.GetAllAsync();

        return View();
    }

    public IActionResult Order()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
