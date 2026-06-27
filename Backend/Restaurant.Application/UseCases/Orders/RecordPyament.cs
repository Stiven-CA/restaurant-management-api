using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Repositories;
using Restaurant.Application.DTOs.Order;

namespace Restaurant.Application.UseCases.Orders;

public class RecordPayment{

    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly ITableRepository _tableRepository;


    public RecordPayment(IOrderRepository orderRepository,
                         IOrderDetailRepository orderDetailRepository,
                         ITableRepository tableRepository){
    
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
        _tableRepository = tableRepository;
    }

    public async Task<OrderResponseDto> ExecuteAsync(Guid OrderId, decimal AmountPaid)
    {
        var order = await _orderRepository.GetById(OrderId);
        if(order == null)
            throw new ArgumentException("La Orden no Existe");
        if(order.Status != OrderStatus.Open)
            throw new ArgumentException("El pedido no esta abierto");

        var orderDetail = await _orderDetailRepository.GetByOrder(OrderId);
        decimal total = orderDetail.Sum(od => od.Quantity * od.UnitPrice);
        if(AmountPaid < total)  
            throw new ArgumentException("El pago no es suficiente");

        order.ChangeStatus(OrderStatus.Paid);
        await _orderRepository.Update(order);

        var table = await _tableRepository.GetById(order.TableId);
        table.ChangeStatus(TableStatus.Free);

        await _tableRepository.Update(table);

        return new OrderResponseDto
        {
            OrderDateTime = order.OrderDateTime,
            Status = order.Status.ToString(),
            TableId = order.TableId
        };
        
    }
}
