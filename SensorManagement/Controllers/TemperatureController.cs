using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorManagement.Authorization;
using SensorManagement.Models.Temperature;
using SensorManagement.Models.Users;
using SensorManagement.Services;

namespace SensorManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/temperature")]
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

        [Authorize(Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var logs = _temperatureService.GetAll();
            return Ok(logs);
        }

        [Authorize(Role.Sensor)]
        [HttpPost]
        public IActionResult Create(TemperatureCreateRequest model)
        {
            var currentUser = (User)HttpContext.Items["User"];
            _temperatureService.Create(currentUser.Id, model);
            return Ok(new { message = "Temperature log created" });
        }
    }
}
