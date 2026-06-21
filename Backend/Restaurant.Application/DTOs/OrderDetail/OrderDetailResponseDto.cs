namespace Restaurant.Application.DTOs.OrderDetail;

public class OrderDetailResponseDto
{
    public  required  int Quantity { get; set; } 
    public  required  decimal UnitPrice { get; set; } 
    public required Guid DishId { get; set; } 
    public required Guid OrderId { get; set; }
}
    

