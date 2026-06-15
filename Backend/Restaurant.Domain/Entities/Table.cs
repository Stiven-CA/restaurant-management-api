using Restaurant.Domain.Enums;
using System.Text.RegularExpressions;
namespace Restaurant.Domain.Entities;

public class Table
{    
    public Guid Id { get; private set; }
    public string Number{ get; private set; }
    public int Capacity { get; private set; }

    public TableStatus Status{ get; private set; }

    public Table(
        Guid id,
        string number,
        int capacity,
        TableStatus status
    )
    {
        if(Guid.Empty == id)
            throw new ArgumentException("El ID no puede estar vacio");
        Id = id;

        if(string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("El Numero no puede estar vacio");
        Number = number;

        if(capacity <= 0)
            throw new ArgumentException("La Capacidad no puede ser menor o iguala cero");
        Capacity = capacity;

        if(!Enum.IsDefined(status))
            throw new ArgumentException("El estado no puede estar vacio");
        Status = status;

    }




    
}