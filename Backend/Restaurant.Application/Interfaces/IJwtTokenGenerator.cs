using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces;


public interface IJwtTokenGenerator{

    string TokenGenerator(User user);


}