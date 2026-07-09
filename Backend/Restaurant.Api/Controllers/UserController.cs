using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.User;
using Restaurant.Application.UseCases.Users;
using Restaurant.Api.DTOs.User;

namespace Restaurant.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly Login _login;
    private readonly RegisterUser _registerUser;

    public UserController(Login login, RegisterUser registerUser)
    {
        _login = login;
        _registerUser = registerUser;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        try
        {
        var result = await _login.ExecuteAsync(request.Email, request.Password);
        return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequestDto request)
    {
        try
        {
            var result = await _registerUser.ExecuteAsync(request);
            return Created("",result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}