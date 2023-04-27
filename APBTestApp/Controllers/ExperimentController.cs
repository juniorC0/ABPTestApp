using ABPTestApp.Application.Interfaces;
using ABPTestApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace APBTestApp.API.Controllers
{
    [Route("api/experiment")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        private readonly IExperimentService _experimentService;
        private readonly IRepository _repository;

        public ExperimentController(IExperimentService experimentService, IRepository repository)
        {
            _experimentService = experimentService;
            _repository = repository;
        }

        [HttpGet]
        [Route("button-color")]
        public async Task<IActionResult> GetButtonColor([FromQuery] string deviceToken)
        {
            if (string.IsNullOrEmpty(deviceToken))
            {
                return BadRequest();
            }

            var experiment = await _experimentService.GetButtonColorAsync(deviceToken);

            if (experiment is null)
            {
                return NotFound();
            }

            var result = new Dictionary<string, string>()
            {
                { "key", experiment.Name },
                { "value", experiment.Option }
            };

            return Ok(result);
        }

        [HttpGet]
        [Route("price")]
        public async Task<IActionResult> GetPrice([FromQuery] string deviceToken)
        {
            if (string.IsNullOrEmpty(deviceToken))
            {
                return BadRequest();
            }
            var experiment = await _experimentService.GetPriceAsync(deviceToken);

            if (experiment is null)
            {
                return NotFound();
            }

            var result = new Dictionary<string, string>()
            {
                { "key", experiment.Name },
                { "value", experiment.Option }
            };

            return Ok(result);
        }

        //Контроллер для получения всех девайсов для отображения статистики
        [HttpGet]
        [Route("all-devices")]
        public async Task<IActionResult> GetAllDevices()
        {
            var allDevices = await _repository.GetAllDevicesAsync();
            return Ok(allDevices);
        }
    }
}
