using Restaurant.Domain.Enums;
namespace Restaurant.Domain.Entities;

public class Dish{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public Boolean SoldOut { get; private set; }

    public DishCategory Category { get; private set; }

    public Dish(
        Guid id,
        string name,
        string description,
        decimal price,
        Boolean soldout,
        DishCategory category
    )
    {
        if(Guid.Empty == id)
            throw new ArgumentException("El ID no puede estar vacio");
        Id = id;

        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El Nombre no puede estar vacio");
        Name = name;

        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("la Descripcion no puede estar vacia");

        if(description.Length > 400)
            throw new ArgumentException("La descripcion no puede tener mas de 400 caracteres");
        Description = description;

        if(price <= 0 )
            throw new ArgumentException("El Precio no puede ser negativo o ser cero");
        Price = price;

        SoldOut = soldout;

        if(!Enum.IsDefined(category))
            throw new ArgumentException("La categoria no puede estar vacia");
        Category = category;

    }

}