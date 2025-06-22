using Microsoft.EntityFrameworkCore;
using OrderDelivery.Models;

namespace OrderDelivery.DataAccessLayer.Context;

public class OrderDeliveryDbContext : DbContext
{
    public OrderDeliveryDbContext(DbContextOptions<OrderDeliveryDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.SenderCity).IsRequired().HasMaxLength(100);
            entity.Property(e => e.SenderAddress).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ReceiverCity).IsRequired().HasMaxLength(100);
            entity.Property(e => e.ReceiverAddress).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Weight).IsRequired().HasPrecision(10, 3);
        });

        modelBuilder.Entity<Order>().ToTable("Orders");
    }
}