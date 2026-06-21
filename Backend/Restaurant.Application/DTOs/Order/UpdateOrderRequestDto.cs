namespace Restaurant.Application.DTOs.Order;

public class UpdateOrderRequestDto
{
    
    public   DateTime? OrderDateTime { get; set; } 
    public   Guid? TableId { get; set; } 
    public  Guid? WaiterId{ get; set; } 
}