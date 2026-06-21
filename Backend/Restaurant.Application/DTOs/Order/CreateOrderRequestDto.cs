namespace Restaurant.Application.DTOs.Order;

public class CreateOrderRequestDto
{
    
    public  required DateTime OrderDateTime { get; set; } 
    public  required Guid TableId { get; set; } 
    public required Guid WaiterId{ get; set; } 
}