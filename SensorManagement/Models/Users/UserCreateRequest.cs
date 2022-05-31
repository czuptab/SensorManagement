namespace SensorManagement.Models.Users;

using System.ComponentModel.DataAnnotations;

public class UserCreateRequest
{

    [Required]
    public string Username { get; set; }

    [Required]
    public string Name { get; set; }

    
    [Required]
    [EnumDataType(typeof(Role))]
    public string Role { get; set; }

    [Required]
    [MinLength(5)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}