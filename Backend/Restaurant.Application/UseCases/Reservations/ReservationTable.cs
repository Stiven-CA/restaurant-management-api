using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Domain.Enums;

namespace Restaurant.Application.UseCases.Reservations;

public class ReservationTable{

    private readonly IReservationRepository _reservationRepository;
    private readonly ITableRepository _tableRepository;
    
    public ReservationTable(IReservationRepository reservationRepository,
                            ITableRepository tableRepository){
        _reservationRepository = reservationRepository;
        _tableRepository = tableRepository;
    }

    public async Task<ReservationResponseDto> ExecuteAsync(CreateReservationRequestDto request)
    {
        // Paso 1: Buscar mesa disponible
        var tables = await _tableRepository.GetAvailable(request.NPeople);
        if(!tables.Any())
            throw new ArgumentException("No hay mesas disponibles");
        var table = tables.FirstOrDefault();

        // Paso 2: Cambiar estado de la mesa y actualizar
        table.ChangeStatus(TableStatus.Reserved);
        await _tableRepository.Update(table);

        // Paso 3: Crear la reservación
        var reservation = new Reservation(
            Guid.NewGuid(),
            request.Date,
            request.Time,
            request.NPeople,
            ReservationStatus.Confirmed,
            request.CustomerId,
            table.Id 
        );

        // Paso 4: Persistir y retornar
        await _reservationRepository.Add(reservation);
        return new ReservationResponseDto { 
            Date = reservation.ReservationDate,
            Time = reservation.ReservationTime,
            NPeople = reservation.NPeople,
            Status = reservation.Status.ToString(),
            CustomerId = reservation.CustomerId,
            TableId = reservation.TableId

         };
    }
}