using ABPTestApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBTestApp.API.Controllers
{
    [Route("api/experiment")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        private readonly IExperimentService _experimentService;

        public ExperimentController(IExperimentService experimentService)
        {
            _experimentService = experimentService;
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
    }
}
