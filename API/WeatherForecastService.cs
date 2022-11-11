using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public IEnumerable<WeatherForecast> Get(int resultsCount, int minValue, int maxValue)
        {
            var rng = new Random();
            return Enumerable.Range(1, resultsCount).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(minValue, maxValue),
                Summary = Summaries[rng.Next(Summaries.Length)]


            })
               .ToArray();
        }

        public IEnumerable<WeatherForecast> Get()
        {
            throw new NotImplementedException();
        }
    }
}
