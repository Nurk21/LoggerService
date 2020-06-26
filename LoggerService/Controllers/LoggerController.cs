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
using LoggerService.DAL.Repositories;

namespace LoggerService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoggerController : ControllerBase
    {
        private readonly IMongoRepository<Log> _mongoRepository;
        public LoggerController(IMongoRepository<Log> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        [HttpGet]
        public async Task<List<string>> GetAllasync()
        {
            return await _mongoRepository.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string jsonString)
        {
            await _mongoRepository.AddAsync(jsonString);
            return Ok();        
        }
    }
}
