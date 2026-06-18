namespace Restaurant.Application.DTOs;

public class OrderResponseDto
{
    public  required DateTime OrderDateTime { get; set; } 
    public  required String Status { get; set; } 
    public  required Guid TableId { get; set; } 
}
