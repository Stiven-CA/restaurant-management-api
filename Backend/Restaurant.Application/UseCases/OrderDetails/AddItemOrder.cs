using Restaurant.Domain.Repositories;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Entities;
using Restaurant.Application.DTOs.OrderDetail;

namespace Restaurant.Application.UseCases.OrderDetails;

public class AddItemOrder{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IDishRepository _dishRepository;

    public AddItemOrder(IOrderDetailRepository orderDetailRepository,
                    IOrderRepository orderRepository,
                    IDishRepository dishRepository){

        _orderDetailRepository = orderDetailRepository;
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
    }
    
    public async Task<OrderDetailResponseDto> ExecuteAsync(Guid OrderId, Guid DishId, int Quantity)
    {
        var order = await _orderRepository.GetById(OrderId);
        if(order == null)
            throw new ArgumentException("La Orden no existe ");
        if(order.Status == OrderStatus.Paid)
            throw new ArgumentException("La Order ya esta completada");
        
        var dish = await _dishRepository.GetById(DishId);
        if(dish == null)
            throw new ArgumentException("El Plato no Existe");
        if(dish.SoldOut)
            throw new ArgumentException("El plato esta agotado");
        
        var orderDetail = new OrderDetail(
            Guid.NewGuid(),
            Quantity,
            dish.Price,
            DishId,
            OrderId

        );
        await _orderDetailRepository.Add(orderDetail);

        return new OrderDetailResponseDto
        {
            Quantity = orderDetail.Quantity,
            UnitPrice = orderDetail.UnitPrice,
            DishId = orderDetail.DishId,
            OrderId =orderDetail.OrderId
        };

    }
}