using Restaurant.Domain.Repositories;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.UseCases.Users;

public class Login{

    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public  Login(IUserRepository userRepository, 
                         IPasswordHasher passwordHasher,
                         IJwtTokenGenerator jwtTokenGenerator){
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<String> ExecuteAsync(String Email, String Password)
    {
        var user = await _userRepository.GetByEmail(Email);
        if(user == null)    
            throw new ArgumentException("El usuario no existe");

        var hashedPassword = _passwordHasher.Hash(Password);
        if(user.Password != hashedPassword) 
            throw new ArgumentException("La contraseña es incorrecta");

        var token = _jwtTokenGenerator.TokenGenerator(user);

        return token;
        


    }
}