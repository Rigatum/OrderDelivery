using OrderDelivery.DataAccessLayer.Repositories;
using OrderDelivery.Services;

namespace OrderDelivery.Utils.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
        serviceCollection.AddScoped<IOrderService, OrderService>();
    }
}