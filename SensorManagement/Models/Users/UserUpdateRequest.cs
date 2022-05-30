namespace SensorManagement.Models.Users;

using System.ComponentModel.DataAnnotations;

public class UserUpdateRequest
{
    public string Name { get; set; }

    [EnumDataType(typeof(Role))]
    public string Role { get; set; }

    private string _password;
    [MinLength(6)]
    public string Password
    {
        get => _password;
        set => _password = string.IsNullOrEmpty(value) ? null : value;
    }

    private string _confirmPassword;
    [Compare("Password")]
    public string ConfirmPassword
    {
        get => _confirmPassword;
        set => _confirmPassword = string.IsNullOrEmpty(value) ? null : value;
    }
}