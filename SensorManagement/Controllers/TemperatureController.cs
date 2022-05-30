using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorManagement.Models.Temperature;
using SensorManagement.Services;

namespace SensorManagement.Controllers
{
    [ApiController]
    [Route("[controller]/temperature")]
    public class TemperatureController : ControllerBase
    {
        private ISensorService _temperatureService;
        private IMapper _mapper;

        public TemperatureController(
            ISensorService temperatureService,
            IMapper mapper)
        {
            _temperatureService = temperatureService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(TemperatureCreateRequest model)
        {
            _temperatureService.Create(model);
            return Ok(new { message = "Temperature log created" });
        }
    }
}
