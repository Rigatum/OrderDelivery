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

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is Entity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            var entity = (Entity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.DateCreatedUtc = utcNow;
                entity.DateModifiedUtc = utcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entity.DateModifiedUtc = utcNow;
            }
        }
    }
}