using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface ITableRepository
{
    Table Add(Table table);
    Table Delete(Guid id);

    Table Update(Table table);

    Table GetById(Guid id);
    List<Table> GetCapacity(int capacity);
    List<Table> GetAll();
}