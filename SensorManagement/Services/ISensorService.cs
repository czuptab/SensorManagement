namespace SensorManagement.Services;

using SensorManagement.Models.Temperature;

public interface ISensorService
{
    void Create(TemperatureCreateRequest model);
}