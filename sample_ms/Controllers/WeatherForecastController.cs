using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sample_ms.Models;
using sample_ms.Services;

namespace sample_ms.Controllers
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
        private readonly DemoService _demoService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DemoService demoService)
        {
            _logger = logger;
            _demoService = demoService;
        }

        [HttpGet]
        public ActionResult<List<WeatherForecast>> Get() =>
            _demoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetWeatherForecast")]
        public ActionResult<WeatherForecast> Get(string id)
        {
            var demo = _demoService.Get(id);

            if (demo == null)
            {
                return NotFound();
            }

            return demo;
        }

        [HttpPost]
        public ActionResult<WeatherForecast> Create(WeatherForecast demo)
        {
            _demoService.Create(demo);

            return CreatedAtRoute("GetWeatherForecast", new { id = demo.Id.ToString() }, demo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, WeatherForecast demoIn)
        {
            var demo = _demoService.Get(id);

            if (demo == null)
            {
                return NotFound();
            }

            _demoService.Update(id, demoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var demo = _demoService.Get(id);

            if (demo == null)
            {
                return NotFound();
            }

            _demoService.Remove(demo.Id);

            return NoContent();
        }

        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}
