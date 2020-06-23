using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoggerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllasync(/*[FromQuery] Guid sessionID*/)
        {
            return Ok();
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Create(/*[FromQuery] bool result, [FromForm] OschadResponseOnSuccess content*/)
        {
            return Ok();
        }

    }
}
