using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;
using Restaurant.Application.DTOs.User;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.UseCases.Users;

public class RegisterUser{

    private  readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwodHasher;

    public  RegisterUser(IUserRepository userRepository, 
                         IPasswordHasher passwordHasger){
        _userRepository = userRepository;
        _passwodHasher = passwordHasger;
    }

    public async Task<UserResponseDto> ExecuteAsync(CreateUserRequestDto request)
    {
        var existing = await _userRepository.GetByEmail(request.Email);
        if (existing != null)
            throw new ArgumentException("El email ya está registrado");
        var hashedPassword = _passwodHasher.Hash(request.Password);
        var user = new User(
            Guid.NewGuid(),
            request.Name,
            request.Email,
            hashedPassword,
            request.Role
        );
        await _userRepository.Add(user);

        return new UserResponseDto
        {
            Name = user.Name,
            Email = user.Email,
        };
    }
}