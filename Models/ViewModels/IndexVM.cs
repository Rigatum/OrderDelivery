namespace OrderDelivery.Models.ViewModels;

public class IndexVM
{
    public IEnumerable<OrderVM> Orders { get; set; } = new List<OrderVM>();
}