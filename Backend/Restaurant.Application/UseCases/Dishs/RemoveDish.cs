using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;        // ← agrega esta línea
using Restaurant.Application.DTOs.Dish;
namespace Restaurant.Application.UseCases.Dishs;
public class RemoveDish{

    private readonly IDishRepository _dishRepository;

    public RemoveDish(IDishRepository dishRepository){
        _dishRepository = dishRepository;
    }

    public async Task<DishResponseDto> ExecuteAsync(Guid id){
        var dish = await _dishRepository.GetById(id);
        if(dish == null)
            throw new ArgumentException("El Plato no existe");
        await _dishRepository.Delete(id);

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