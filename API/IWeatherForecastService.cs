using System.Collections.Generic;

namespace API
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int resultsNum, int minValue, int maxValue);
    }
}