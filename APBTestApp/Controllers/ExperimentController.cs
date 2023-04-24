using ABPTestApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
            var experiment = await _experimentService.GetButtonColorAsync(deviceToken);

            var result = new Dictionary<string, string>()
            {
                { "key", experiment.Name },
                { "value", experiment.Option }
            };

            return Ok(result);
        }

        [HttpGet]
        [Route("price")]
        public IActionResult GetPrice([FromQuery] string deviceToken)
        {
            return Ok();
        }
    }
}
