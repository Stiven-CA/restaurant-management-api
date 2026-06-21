namespace Restaurant.Application.DTOs.OrderDetail;

public class UpdateOrderDetailRequestDto
{
    
    public   int? Quantity { get; set; } 
    public   decimal? UnitPrice { get; set; } 
    public  Guid? DishId { get; set; } 
    public Guid? OrderId { get; set; }
}
