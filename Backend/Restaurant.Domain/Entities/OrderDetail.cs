namespace Restaurant.Domain.Entities;

public class OrderDetail
{
    public Guid Id { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public Guid DishId{ get; private set; }
    public Guid OrderId{ get; private set; }

    public OrderDetail(
        Guid id,
        int quantity,
        decimal unitPrice,
        Guid dishId,
        Guid orderId
    )
    {

        if(Guid.Empty == id)
            throw new ArgumentException("El ID no puede estar vacio");
        Id = id;

        if(quantity <= 0)
            throw new ArgumentException("La Cantidad no puede ser igual o menos a cero");
        Quantity = quantity;

        if(unitPrice <= 0)
            throw new ArgumentException("El Precio no puede ser igual o menos a cero");
        UnitPrice = unitPrice;

        if(Guid.Empty == dishId)
            throw new ArgumentException("El ID no puede estar vacio");
        DishId = dishId;

        if(Guid.Empty == orderId)
            throw new ArgumentException("El ID no puede estar vacio");
        OrderId = orderId;

    }
}