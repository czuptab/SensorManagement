using SensorManagement.Models.Users;

namespace SensorManagement.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(UserCreateRequest model);
        void Update(int id, UserUpdateRequest model);
        void Delete(int id);
        UserAuthenticateResponse Authenticate(UserAuthenticateRequest model);
    }
}
