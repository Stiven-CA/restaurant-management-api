namespace Restaurant.Application.DTOs;

public class CreateOrderRequestDto
{
    
    public  required DateTime OrderDateTime { get; set; } 
    public  required Guid TableId { get; set; } 
    public required Guid WaiterId{ get; set; } 
}