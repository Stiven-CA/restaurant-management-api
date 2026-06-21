using Restaurant.Domain.Enums;
namespace Restaurant.Application.DTOs.Dish;
public class UpdateDishRequestDto
{
    public  string? Name{ get; set; }
    public  string? Description{ get; set; }
    public  decimal? Price { get; set; }
    public  DishCategory? Category{ get; set; }

}
