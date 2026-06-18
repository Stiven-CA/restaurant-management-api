using Restaurant.Domain.Enums;

namespace Restaurant.Application.DTOs;


public class CreateTableRequestDto
{
    public  required string Number { get; set; } 
    public  required int Capacity { get; set; } 
    public  required TableStatus Status { get; set; } 
}
