namespace SensorManagement.Models.Temperature;

public class TemperatureLog
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public float Temperature { get; set; }
}
