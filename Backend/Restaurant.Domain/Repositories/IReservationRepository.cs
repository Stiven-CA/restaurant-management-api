using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IReservationRepository
{
    Reservation Add(Reservation reservation);
    Reservation Update(Reservation reservation);
    Reservation Delete(Guid id);

    Reservation? GetById(Guid id);
    List<Reservation> GetAll();
    List<Reservation> GetReservations(DateOnly date);
    
}