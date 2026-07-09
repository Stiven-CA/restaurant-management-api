using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.User;

public class LoginRequestDto
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}