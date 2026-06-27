using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IReservationRepository
{
    Task<Reservation> Add(Reservation reservation);
    Task<Reservation> Update(Reservation reservation);
    Task<Reservation> Delete(Guid id);

    Task<Reservation?> GetById(Guid id);
    Task<List<Reservation>> GetAll();
    Task<List<Reservation>> GetReservations(DateTime date);
    Task<Reservation?> GetByTableAndDateTime(Guid tableId, DateTime date, TimeSpan time);
    
}