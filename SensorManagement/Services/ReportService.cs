using AutoMapper;
using SensorManagement.Helpers;
using SensorManagement.Models.Reports;
using SensorManagement.Models.Users;

namespace SensorManagement.Services
{
    public class ReportService : IReportService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ReportService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<AvgTemperature> GetAll()
        {
            //todo: implement date
            List<AvgTemperature> result = new List<AvgTemperature>();
            var sensors = _context.Users.Where(u => u.Role == Role.Sensor).ToList();
            var temperatures = _context.Temperatures;
            foreach (var sensor in sensors)
            {
                var temperaturesForSensor = temperatures.Where(u => u.CreatedBy == sensor.Id);
                var val = temperaturesForSensor.Average(t => t.Temperature);

                result.Add(new AvgTemperature() { SensorId = sensor.Id, AverageTemperature = val });
            }

            return result;
        }
    }
}
