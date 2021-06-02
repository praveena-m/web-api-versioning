using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapidemo.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/WeatherForecast")]
	public class WeatherForecastControllerV3 : WeatherForecastControllerV2
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastControllerV3> _logger;

		public WeatherForecastControllerV3(ILogger<WeatherForecastControllerV3> logger)
		{
			_logger = logger;
		}

		[HttpGet("{min}/{max}")]
		public IEnumerable<WeatherForecast> Get(int min, int max)
		{
			var rng = new Random();
			return Enumerable.Range(1, 10).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(min, max),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
