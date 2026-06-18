using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IOrderRepository
{
    Order Add(Order order);
    Order Update(Order order);
    Order Delete(Guid id);

    Order GetById(Guid id);
    List<Order> GetAll();
    List<Order> GetByDate(DateOnly date);
}