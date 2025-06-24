namespace OrderDelivery.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime DateCreatedUtc { get; set; }
    public DateTime DateModifiedUtc { get; set; }
}
