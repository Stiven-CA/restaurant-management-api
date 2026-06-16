namespace Restaurant.Application.DTOs;

public class CreateOrderDetailRequestDto
{
    
    public  required  int Quantity { get; set; } 
    public  required  decimal UnitPrice { get; set; } 
    public required Guid DishId { get; set; } 
    public required Guid OrderId { get; set; }
}
