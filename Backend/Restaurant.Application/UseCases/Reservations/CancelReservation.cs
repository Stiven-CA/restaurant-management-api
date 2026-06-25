using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Domain.Enums;

namespace Restaurant.Application.UseCases.Reservations;

public class CancelReservation{

    private readonly  IReservationRepository _reservationRepository;
    private readonly ITableRepository _tableRepository;

    public CancelReservation(IReservationRepository reservationRepository,
                             ITableRepository tableRepository){
        _reservationRepository = reservationRepository;
        _tableRepository = tableRepository;
    }

    public async Task<ReservationResponseDto> ExecuteAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetById(id);
        if(reservation == null)
            throw new ArgumentException("La reservacion no existe");

        if(reservation.Status == ReservationStatus.Cancelled)
            throw new ArgumentException("La reservacion ya esta cancelada");

        if(reservation.Status == ReservationStatus.Completed)
            throw new ArgumentException("La reservacion ya esta completada");

        var table = await _tableRepository.GetById(reservation.TableId);
        reservation.ChangeStatus(ReservationStatus.Cancelled);
        table.ChangeStatus(TableStatus.Free);

        await _reservationRepository.Update(reservation);
        await _tableRepository.Update(table);
        
        return new ReservationResponseDto
        {
            Date = reservation.ReservationDate,
            Time = reservation.ReservationTime,
            NPeople = reservation.NPeople,
            Status = reservation.Status.ToString(),
            CustomerId = reservation.CustomerId,
            TableId = reservation.TableId
        };

    }
}