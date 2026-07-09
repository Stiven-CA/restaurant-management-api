using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Order;
using Restaurant.Application.UseCases.Orders;
using Restaurant.Application.DTOs.OrderDetail;
using Restaurant.Api.DTOs.Order;
using Restaurant.Application.UseCases.OrderDetails;

namespace Restaurant.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OpenOrder _openOrder;
    private readonly AddItemOrder _addItemOrder;
    private readonly RecordPayment _recordPayment;

    public OrderController(OpenOrder openOrder, AddItemOrder additemOrder, RecordPayment recordPayment)
    {
        _openOrder = openOrder;
        _addItemOrder = additemOrder;
        _recordPayment = recordPayment;
    }

    [HttpPost("open")]
    public async Task<IActionResult> OpenOrder([FromBody] CreateOrderRequestDto request)
    {
        try
        {
        var result = await _openOrder.ExecuteAsync(request.TableId, request.WaiterId, request.CustomerId);
        return Created("", result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost("additem")]
    public async Task<IActionResult> AddItemOrder([FromBody] CreateOrderDetailRequestDto request)
    {
        try
        {
        var result = await _addItemOrder.ExecuteAsync(request.OrderId, request.DishId, request.Quantity);
        return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("recordpayment")]
    public async Task<IActionResult> RecordPayment([FromBody] RecordPaymentRequestDto request)
    {
        try
        {
        var result = await _recordPayment.ExecuteAsync(request.OrderId, request.AmountPaid);
        return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}