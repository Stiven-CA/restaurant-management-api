using Restaurant.Domain.Enums;
namespace Restaurant.Application.DTOs;

public class UpdateTableRequestDto
{
    public   string? Number { get; set; } 
    public   int? Capacity { get; set; } 
    public   TableStatus? Status { get; set; } 
}
