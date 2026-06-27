using Restaurant.Domain.Enums;
namespace Restaurant.Domain.Entities;

public class Reservation{
    public Guid Id { get; private set; }
    public DateOnly ReservationDate { get; private set; }
    public TimeOnly ReservationTime { get; private set; }
    public int NPeople { get; private set; }
    public ReservationStatus Status{ get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid TableId { get; private set; }

    public Reservation(
        Guid id,
        DateOnly reservationDate,
        TimeOnly reservationTime,
        int nPeople,
        ReservationStatus status,
        Guid customerId,
        Guid tableId
    )
    {
        if(Guid.Empty == id)
            throw new ArgumentException("El ID no puede estar vacio");
        Id = id;

        if(reservationDate < DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("La Fecha no puedde ser atigua");
        ReservationDate = reservationDate;

        if(reservationTime < TimeOnly.FromDateTime(DateTime.Now))
            throw new ArgumentException("la Hora no puede sre antigua");
        ReservationTime = reservationTime;

        if(nPeople <= 0)
            throw new ArgumentException("El Numero de personas no puede ser menor o igual a cero");
        NPeople = nPeople;

        if(!Enum.IsDefined(status))
            throw new ArgumentException("El Estado de reserva no puede estar vacio");
        Status = status;

        if(Guid.Empty == customerId)
            throw new ArgumentException("El ID no puede estar vacio");
        CustomerId = customerId;

        if(Guid.Empty == tableId)
            throw new ArgumentException("El ID no puede estar vacio");
        TableId = tableId;
    }
    public void ChangeStatus(ReservationStatus newStatus)
    {
        if(!Enum.IsDefined(newStatus))
            throw new ArgumentException("Estado inválido");
        Status = newStatus;
    }
    
}