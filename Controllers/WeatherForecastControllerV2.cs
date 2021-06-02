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
	public class WeatherForecastControllerV2 : WeatherForecastControllerV1
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};


		public WeatherForecastControllerV2()
		{
		}

		[HttpGet("{id}")]
		public IEnumerable<WeatherForecast> Get(int id)
		{
			var rng = new Random();
			return Enumerable.Range(1, id).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
