using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger; 
            _service = service;

        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int resultsCount,
            [FromBody] TemperatureRequest request)
        {
            if (resultsCount < 0 || request.Max < request.Min)
            {
                return StatusCode(400, "Try again");

            }

            var result = _service.Get(resultsCount, request.Min, request.Max);
            return StatusCode(200, result); 

        }



        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var result = _service.Get();
        //    return result;
        //}

        //[HttpGet("currentDay/{max}")]
        //public IEnumerable<WeatherForecast> Get2([FromQuery] int take, [FromRoute]int max)
        //{
        //    var result = _service.Get();
        //    return result;
        //}

        //[HttpPost("generate")]
        //public ActionResult<string> Hello([FromBody]string name)
        //{
        //    //HttpContext.Response.StatusCode = 401;
        //    //return StatusCode(401, $"Hello {name}");
        //    return NotFound($"Hello {name}");
        //}
    }
}
