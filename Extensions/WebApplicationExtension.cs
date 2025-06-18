using Microsoft.EntityFrameworkCore;
using OrderDelivery.DataAccessLayer.Context;

namespace OrderDelivery.Extensions;

public static class WebApplicationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OrderDeliveryDbContext>();
        context.Database.Migrate();
    }
}