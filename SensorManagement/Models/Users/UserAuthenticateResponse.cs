namespace SensorManagement.Models.Users
{
    public class UserAuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }


        public UserAuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Name = user.Name;
            Role = user.Role;
            Token = token;
        }
    }
}
