using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Repositories;

public interface IDishRepository
{
    Task<Dish> Add(Dish dish);
    Task<Dish> Update(Dish dish);
    Task<Dish> Delete(Guid id);

    Task<Dish> GetById(Guid id);
    Task<List<Dish>> GetCategory(DishCategory category);
    Task<List<Dish>> GetAll();
}