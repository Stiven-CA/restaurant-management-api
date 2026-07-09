using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.UseCases.Dishs;
using Restaurant.Application.DTOs.Dish;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishController : ControllerBase
{
    private readonly AddDish _addDish;
    private readonly RemoveDish _removeDish;

    public DishController(AddDish addDish, RemoveDish removeDish)
    {
        _addDish = addDish;
        _removeDish = removeDish;
    }
    [HttpPost]
    public async Task<IActionResult> AddDish([FromBody] CreateDishRequestDto requestDto)
    {
        try
        {
            var result = await _addDish.ExecuteAsync(requestDto);
            return Created("", result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveDish([FromRoute] Guid id)
    {
        try
        {
            var result = await _removeDish.ExecuteAsync(id);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
