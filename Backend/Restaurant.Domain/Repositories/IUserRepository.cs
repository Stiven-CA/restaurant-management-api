using Restaurant.Domain.Entities;
namespace Restaurant.Domain.Repositories;

public interface IUserRepository
{
    User Add(User user);
    User Update(User user);

    User GetById(Guid id);
    User Delete(Guid id);
    User GetByEmail(string email);

    List<User> GetAll();
}