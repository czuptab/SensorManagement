namespace SensorManagement.Services;

using AutoMapper;
using SensorManagement.Helpers;
using SensorManagement.Models.Temperature;
using System.Collections.Generic;

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

    public IEnumerable<TemperatureLog> GetAll()
    {
        return _context.Temperatures;
    }

    public void Create(long sensorId, TemperatureCreateRequest model)
    {
        var log = _mapper.Map<TemperatureLog>(model);
        log.CreatedBy = sensorId;

        _context.Temperatures.Add(log);
        _context.SaveChanges();
    }
}