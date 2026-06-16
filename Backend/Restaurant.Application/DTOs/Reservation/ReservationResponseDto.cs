namespace Restaurant.Application.DTOs;

public class ReservationResponseDto
{

    public required  DateOnly Date { get; set; } 
    public required  TimeOnly Time { get; set; } 
    public required int NPeople { get; set; } 
    public required string Status { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid TableId  { get; set; }

}
   

