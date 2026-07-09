using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.SalesReport;

public class SalesReportRequestDto
{
    [Required]
    public required DateTime ReportDate { get; set; }
    [Required]
    public required Guid AdminId { get; set; }
}
