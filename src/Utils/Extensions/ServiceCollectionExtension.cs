using OrderDelivery.DataAccessLayer;
using OrderDelivery.DataAccessLayer.Repositories;
using OrderDelivery.Services;

namespace OrderDelivery.Utils.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IOrderService, OrderService>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}