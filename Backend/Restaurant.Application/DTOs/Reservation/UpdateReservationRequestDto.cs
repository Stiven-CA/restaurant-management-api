namespace Restaurant.Application.DTOs.Reservarion;

public class UpdateReservationRequestDto
{

    public   DateOnly? Date { get; set; } 
    public   TimeOnly? Time { get; set; } 
    public  int? NPeople { get; set; } 
    public  string? Status { get; set; }
    public  Guid? CustomerId { get; set; }
    public  Guid? TableId  { get; set; }
}
