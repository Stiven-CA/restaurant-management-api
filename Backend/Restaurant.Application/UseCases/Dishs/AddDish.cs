using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;        // ← agrega esta línea
using Restaurant.Application.DTOs.Dish;
namespace Restaurant.Application.UseCases.Dishs;
public class AddDish{

    private readonly IDishRepository _dishRepository;

    public AddDish(IDishRepository dishRepository){
        _dishRepository = dishRepository;
    }

    public async Task<DishResponseDto> ExecuteAsync(CreateDishRequestDto request)
    {


        var dish = new Dish( 
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.Price,
            false,
            request.Category

        );
    
        await _dishRepository.Add(dish);
        
        return new DishResponseDto
        {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Category = dish.Category.ToString(), // enum → string, como definiste
                SoldOut = dish.SoldOut
        };
                    
    }

}