using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Repositories;

public interface IDishRepository
{
    Dish Add(Dish dish);
    Dish Update(Dish dish);
    Dish Delete(Guid id);

    Dish GetById(Guid id);
    List<Dish> GetCategory(DishCategory category);
    List<Dish> GetAll();
}