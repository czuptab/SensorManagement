using SensorManagement.Models.Reports;
using SensorManagement.Models.Temperature;
using SensorManagement.Models.Users;

namespace SensorManagement.Services;

public interface IUserService
{
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Create(UserCreateRequest model);
    void Update(int id, UserUpdateRequest model);
    void Delete(int id);
    UserAuthenticateResponse Authenticate(UserAuthenticateRequest model);
}
public interface ISensorService
{
    IEnumerable<TemperatureLog> GetAll();
    void Create(long sensorId, TemperatureCreateRequest model);
}

public interface IReportService
{
    IEnumerable<AvgTemperature> GetAll();
}
