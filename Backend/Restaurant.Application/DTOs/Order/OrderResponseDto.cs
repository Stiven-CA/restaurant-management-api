namespace Restaurant.Application.DTOs.Order;

public class OrderResponseDto
{
    public  required DateTime OrderDateTime { get; set; } 
    public  required String Status { get; set; } 
    public  required Guid TableId { get; set; } 
}
