using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface ITableRepository
{
    Task<Table> Add(Table table);
    Task<Table> Delete(Guid id);

    Task<Table> Update(Table table);

    Task<Table> GetById(Guid id);
    Task<List<Table>> GetCapacity(int capacity);
    Task<List<Table>> GetAvailable(int capacity);
    Task<List<Table>> GetAll();
}