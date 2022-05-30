namespace SensorManagement.Services;

using AutoMapper;
using SensorManagement.Helpers;
using SensorManagement.Models.Temperature;

public class TemperatureService : ISensorService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public TemperatureService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(TemperatureCreateRequest model)
    {
        var log = _mapper.Map<TemperatureLog>(model);

        _context.Temperatures.Add(log);
        _context.SaveChanges();
    }
}