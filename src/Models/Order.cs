using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDelivery.Models;

public class Order: Entity
{
    public string OrderNumber { get; set; } = string.Empty;
    public string SenderCity { get; set; } = string.Empty;
    public string SenderAddress { get; set; } = string.Empty;
    public string ReceiverCity { get; set; } = string.Empty;
    public string ReceiverAddress { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18, 3)")]
    public float Weight { get; set; }
    public DateTime PickupDate { get; set; }
}