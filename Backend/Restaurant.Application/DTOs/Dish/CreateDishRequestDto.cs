using Restaurant.Domain.Enums;
namespace Restaurant.Application.DTOs;

public class CreateDishRequestDto
{
    public required string Name{ get; set; }
    public required string Description{ get; set; }
    public required decimal Price { get; set; }
    public required DishCategory Category{ get; set; }



    
}
