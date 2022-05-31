namespace SensorManagement.Services;

using SensorManagement.Models.Temperature;

public interface ISensorService
{
    IEnumerable<TemperatureLog> GetAll();
    void Create(long sensorId, TemperatureCreateRequest model);
}