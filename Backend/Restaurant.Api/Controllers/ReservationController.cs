using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Application.UseCases.Reservations;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ReservationController : ControllerBase
{
    private readonly ReservationTable _reservationTable;
    private readonly CancelReservation _cancelReservation;

    public ReservationController(ReservationTable reservationTable, CancelReservation cancelReservation)
    {
        _reservationTable = reservationTable;
        _cancelReservation = cancelReservation;
    }
    [HttpPost("reserve")]
    public async Task<IActionResult> ReserveTable([FromBody] CreateReservationRequestDto request)
    {
        try
        {
        var result = await _reservationTable.ExecuteAsync(request);
        return Created("", result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("cancel/{id}")]
    public async Task<IActionResult> CancelReservation([FromRoute] Guid id)
    {
        try
        {
        var result = await _cancelReservation.ExecuteAsync(id);
        return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}