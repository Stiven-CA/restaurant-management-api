using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IOrderDetailRepository
{
    OrderDetail Add(OrderDetail orderDetail);
    OrderDetail Update(OrderDetail orderDetail);
    OrderDetail Delete(Guid id);

    OrderDetail? GetById(Guid id);
    List<OrderDetail> GetAll();

    List<OrderDetail> GetByOrder(Guid orderId);
}