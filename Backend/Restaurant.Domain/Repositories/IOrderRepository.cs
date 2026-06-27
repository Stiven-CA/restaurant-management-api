using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order> Add(Order order);
    Task<Order> Update(Order order);
    Task<Order> Delete(Guid id);

    Task<Order> GetById(Guid id);
    Task<List<Order>> GetAll();
    Task<List<Order>> GetByDate(DateOnly date);
}