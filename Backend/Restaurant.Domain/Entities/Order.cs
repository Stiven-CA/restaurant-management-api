using Restaurant.Domain.Enums;
namespace Restaurant.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public DateTime OrderDateTime { get; private set; }   
    public OrderStatus Status { get; private set; }   
    public Guid WaiterId  { get; private set; }   
    public Guid CustomerId {  get; private set; }
    public Guid TableId {  get; private set; }   


    public Order(
        Guid id,
        DateTime orderDateTime,
        OrderStatus status,
        Guid waiterId,
        Guid tableId,
        Guid customerId

    )
    {
        if(Guid.Empty == id)
            throw new ArgumentException("El ID no puede estar vacio");
        Id = id;
        if(DateTime.Today > orderDateTime)
            throw new ArgumentException("La Fecha no puede ser antigua");
        OrderDateTime = orderDateTime;

        if(!Enum.IsDefined(status))
            throw new ArgumentException("La categoria no puede estar vacia");
        Status = status;

        if(Guid.Empty == waiterId)
            throw new ArgumentException("El ID no puede estar vacio");
        WaiterId = waiterId;

        if(Guid.Empty == tableId)
            throw new ArgumentException("El ID no puede estar vacio");
        TableId = tableId;

        if(Guid.Empty == customerId)
            throw new ArgumentException("El Id no puede estar vacio");
        CustomerId = customerId;
    }

}