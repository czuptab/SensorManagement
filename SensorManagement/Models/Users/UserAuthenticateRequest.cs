using System.ComponentModel.DataAnnotations;

namespace SensorManagement.Models.Users;

public class UserAuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
