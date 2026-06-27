using Restaurant.Domain.Repositories;
using Restaurant.Domain.Enums;
using Restaurant.Application.DTOs.Order;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.UseCases.Orders;

public class OpenOrder{
    private readonly IOrderRepository _orderRepository;
    private readonly ITableRepository _tableRepository;
    private readonly IUserRepository _userRepository;

    public OpenOrder(IOrderRepository orderRepository,
                    ITableRepository tableRepository,
                    IUserRepository userRepository){

        _orderRepository = orderRepository;
        _tableRepository = tableRepository;
        _userRepository = userRepository;
    }

    public async Task<OrderResponseDto> ExecuteAsync(Guid TableId, Guid WaiterId, Guid CustomerId)
    {
        var table = await _tableRepository.GetById(TableId);
        if(table == null)
            throw new ArgumentException("La Mesa no existe");
        if(table.Status == TableStatus.Occupied)
            throw new ArgumentException("La Mesa esta Ocupada");
        
        var waiter = await _userRepository.GetById(WaiterId);
        if(waiter == null)
            throw new ArgumentException("El Mesero no existe");
        
        var customer = await _userRepository.GetById(CustomerId);
        if(customer == null)
            throw new ArgumentException("El cliente no existe");
        
        var order = new Order(
            Guid.NewGuid(),
            DateTime.Now,
            OrderStatus.Open,
            WaiterId,
            CustomerId,
            TableId
            
        );
        table.ChangeStatus(TableStatus.Occupied);
        await _tableRepository.Update(table);
        await _orderRepository.Add(order);

        return new OrderResponseDto
        {
            OrderDateTime = order.OrderDateTime,
            Status = order.Status.ToString(),
            TableId = order.TableId
        };

    }
}