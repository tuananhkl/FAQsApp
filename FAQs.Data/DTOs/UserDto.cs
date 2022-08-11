using System.ComponentModel.DataAnnotations;

namespace FAQs.Data.DTOs;

public class UserDto : LoginUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    public ICollection<string> Roles { get; set; } = null!;
}

public class LoginUserDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [Required]
    [StringLength(15, ErrorMessage = "'Your Password is limited to {2} to {1} characters", MinimumLength = 1)]
    public string Password { get; set; } = null!;
}

public class GetUsersDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public ICollection<string> Roles { get; set; } = null!;
}