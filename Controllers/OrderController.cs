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

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrderVM createOrderVM)
    {
        if (ModelState.IsValid)
        {
            await _orderService.CreateOrder(createOrderVM);

            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(createOrderVM);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
