namespace SensorManagement.Models.Users;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
}