namespace SensorManagement.Models.Temperature;

using System.ComponentModel.DataAnnotations;

public class TemperatureCreateRequest
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }

    [Required]
    public float Temperature { get; set; }
}
