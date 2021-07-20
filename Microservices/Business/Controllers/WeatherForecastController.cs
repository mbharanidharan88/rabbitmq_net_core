using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISyncBusiness _syncBusiness;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                            ISyncBusiness syncBusiness)
        {
            _logger = logger;
            _syncBusiness = syncBusiness;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _syncBusiness.SyncBusiness(new EventBus.Models.BusinessEventModel
            {
                Id = Guid.NewGuid(),
                Name = "Eclatech Solutions"
            });
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
