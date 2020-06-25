using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using MongoDB.Bson.Serialization;
using LoggerService.BL.Services;

namespace LoggerService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoggerController : ControllerBase
    {
        private readonly ILogRequestsHandler _logRequestHandler ;
        public LoggerController(ILogRequestsHandler logRequestsHandler)
        {
            _logRequestHandler = logRequestsHandler;
        }
        [HttpGet]
        public async Task<List<string>> GetAllasync()
        {
            return await _logRequestHandler.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string jsonString)
        {
            await _logRequestHandler.Create(jsonString);
            return Ok();        
        }
    }
}
