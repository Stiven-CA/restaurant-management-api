using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Table;
using Restaurant.Application.UseCases.Tables;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TableController : ControllerBase
{
    private readonly AddTable _addTable;
    private readonly RemoveTable _removeTable;
    private readonly GetAvailableTables _getAvailableTables;

    public TableController(AddTable addTable, RemoveTable removeTable, GetAvailableTables getAvailableTables)
    {
        _addTable = addTable;
        _removeTable = removeTable;
        _getAvailableTables = getAvailableTables;
    }

    [HttpPost]
    public async Task<IActionResult> AddTable([FromBody] CreateTableRequestDto requestDto)
    {
        try
        {
        var result = await _addTable.ExecuteAsync(requestDto);
        return Created("", result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTable([FromRoute] Guid id)
    {
        try
        {
        var result = await _removeTable.ExecuteAsync(id);
        return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpGet("available/{capacity}")]
    public async Task<IActionResult> GetAvailableTables([FromRoute] int capacity)
    {
        try
        {
            var result = await _getAvailableTables.ExecuteAsync(capacity);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}