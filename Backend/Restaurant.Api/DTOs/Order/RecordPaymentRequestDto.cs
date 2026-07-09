using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.Order;

public class RecordPaymentRequestDto
{
    [Required]
    public required Guid OrderId { get; set; }
    [Required]
    public required decimal AmountPaid { get; set; }
}