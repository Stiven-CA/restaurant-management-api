using Restaurant.Domain.Enums;
using System.Text.RegularExpressions;
namespace Restaurant.Domain.Entities;
public class User
{
    public Guid Id { get; private set; }


    public string Name { get; private set; }


    public string Email { get; private set; }

    public string Password { get; private set; }



    public UserRole Role { get; private set; }

    public User(
        Guid id,
        string name,
        string email,
        string passwordHash,
        UserRole role)
    {
        if(Guid.Empty == id )
            throw new ArgumentException("El ID no puede estar vacio");
        Id = id;

        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El Nombre no puede estar vacio");
        Name = name;

        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("El Email no puede estar vacio");

        if(email.Length > 400)
            throw new ArgumentException("El Email no puede tener mas de 100 caracteres");
            
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("El email no es válido");
        Email = email;

        if(string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("La contraseña no puede estar vacia");
        if(passwordHash.Length < 8)
            throw new ArgumentException("La Contraseña debe tener minimo 8 caracteres");
        Password = passwordHash;

        if(!Enum.IsDefined(role))
            throw new ArgumentException("El rol no puede estar vacio");
        Role = role;
    }
}