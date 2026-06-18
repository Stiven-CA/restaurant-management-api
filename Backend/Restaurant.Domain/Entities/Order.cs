using Restaurant.Domain.Enums;
namespace Restaurant.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public DateTime OrderDate { get; private set; }   
    public OrderStatus Status { get; private set; }   
    public Guid WaiterId  { get; private set; }   
    public Guid TableId {  get; private set; }   

    public Order(
        Guid id,
        DateTime orderDate,
        OrderStatus status,
        Guid waiterId,
        Guid tableId
    )
    {
        if(Guid.Empty == id)
            throw new ArgumentException("El ID no puede estar vacio");
        Id = id;
        if(DateTime.Today > orderDate)
            throw new ArgumentException("La Fecha no puede ser antigua");
        OrderDate = orderDate;

        if(!Enum.IsDefined(status))
            throw new ArgumentException("La categoria no puede estar vacia");
        Status = status;

        if(Guid.Empty == waiterId)
            throw new ArgumentException("El ID no puede estar vacio");
        WaiterId = waiterId;

        if(Guid.Empty == tableId)
            throw new ArgumentException("El ID no puede estar vacio");
        TableId = tableId;
    }

}