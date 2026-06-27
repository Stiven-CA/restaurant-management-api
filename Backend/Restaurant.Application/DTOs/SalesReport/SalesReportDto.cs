namespace Restaurant.Application.DTOs.SalesReport;

public class SalesReportDto{
    public decimal TotalSales { get; set; } 
    public List<TopDishDto> TopDishes { get; set; } = new();
    public int ConfirmedReservations { get; set; } 
    public int CancelledReservations{ get; set; } 
    public int CompletedReservations{ get; set; } 

}