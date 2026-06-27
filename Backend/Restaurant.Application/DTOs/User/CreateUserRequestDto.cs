using Restaurant.Domain.Enums;
namespace Restaurant.Application.DTOs.User;

public class CreateUserRequestDto{
    public required string Name { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
	public required UserRole Role { get; set; }
}