namespace Restaurant.Application.DTOs.Reservation;

public class CreateReservationRequestDto
{
    public required DateOnly Date { get; set; }
    public required TimeOnly Time { get; set; }
    public required int NPeople { get; set; }
    public required Guid CustomerId { get; set; }
}