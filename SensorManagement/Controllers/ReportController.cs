using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorManagement.Authorization;
using SensorManagement.Models.Users;
using SensorManagement.Services;

namespace SensorManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/report")]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;
        private IMapper _mapper;

        public ReportController(
            IReportService reportService,
            IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [Authorize(Role.Admin)]
        [HttpGet/*("{date}")*/]
        public IActionResult GetAll()
        {
            var logs = _reportService.GetAll();
            return Ok(logs);

            //if (DateTime.TryParse(date, out DateTime dateTime))
            //{
            //    var logs = _reportService.GetAll();
            //    return Ok(logs);
            //}

            return BadRequest(new { message = "Bad date format" });
        }
    }
}
