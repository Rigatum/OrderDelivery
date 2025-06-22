using System.ComponentModel.DataAnnotations;

namespace OrderDelivery.Models.ViewModels;
public class CreateOrderVM
{
    [Display(Name = "Номер заказа")]
    public string OrderNumber { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Город отправителя обязателен для заполнения")]
    [Display(Name = "Город отправителя")]
    public string SenderCity { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Адрес отправителя обязателен для заполнения")]
    [Display(Name = "Адрес отправителя")]
    public string SenderAddress { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Город получателя обязателен для заполнения")]
    [Display(Name = "Город получателя")]
    public string ReceiverCity { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Адрес получателя обязателен для заполнения")]
    [Display(Name = "Адрес получателя")]
    public string ReceiverAddress { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Вес груза обязателен для заполнения")]
    [Range(0.001, float.MaxValue, ErrorMessage = "Вес груза должен быть больше 0")]
    [Display(Name = "Вес груза (кг)")]
    public float Weight { get; set; }

    [Required(ErrorMessage = "Дата забора груза обязательна для заполнения")]
    [Display(Name = "Дата забора груза")]
    [DataType(DataType.Date)]
    public DateTime PickupDate { get; set; }
}