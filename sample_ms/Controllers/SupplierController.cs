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
    public class SupplierController : ControllerBase
    {

        private readonly ILogger<SupplierController> _logger;
        private readonly SupplierService _demoService;

        public SupplierController(ILogger<SupplierController> logger, SupplierService demoService)
        {
            _logger = logger;
            _demoService = demoService;
        }

        [HttpGet]
        public ActionResult<List<Suplier>> Get() =>
            _demoService.Get();

        [HttpGet("{id}", Name = "GetWeatherForecast")]
        public ActionResult<Suplier> Get(long id)
        {
            var demo = _demoService.Get(id);

            if (demo == null)
            {
                return NotFound();
            }

            return demo;
        }

        [HttpPost]
        public ActionResult<Suplier> Create(Suplier demo)
        {
            _demoService.Create(demo);

            return CreatedAtRoute("GetWeatherForecast", new { id = demo.Id }, demo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Suplier demoIn)
        {
            var demo = _demoService.Get(id);

            if (demo == null)
            {
                return NotFound();
            }

            _demoService.Update(id, demoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
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
