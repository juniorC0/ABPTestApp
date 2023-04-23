using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APBTestApp.API.Controllers
{
    [Route("api/experiment")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        [HttpGet]
        [Route("button-color")]
        public IActionResult GetButtonColor([FromQuery] string deviceToken)
        {
            return Ok();
        }

        [HttpGet]
        [Route("price")]
        public IActionResult GetPrice([FromQuery] string deviceToken)
        {
            return Ok();
        }
    }
}
