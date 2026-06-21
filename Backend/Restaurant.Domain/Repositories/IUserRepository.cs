using Restaurant.Domain.Entities;
namespace Restaurant.Domain.Repositories;

public interface IUserRepository
{
    Task<User> Add(User user);
    Task<User> Update(User user);

    Task<User> GetById(Guid id);
    Task<User> Delete(Guid id);
    Task<User> GetByEmail(string email);

    Task<List<User>> GetAll();
}