using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IOrderDetailRepository
{
    Task<OrderDetail> Add(OrderDetail orderDetail);
    Task<OrderDetail> Update(OrderDetail orderDetail);
    Task<OrderDetail> Delete(Guid id);

    Task<OrderDetail?> GetById(Guid id);
    Task<List<OrderDetail>> GetAll();

    Task<List<OrderDetail>> GetByOrder(Guid orderId);
}