using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication_Dapper.DataCenter;
using WebApplication_Dapper.Model;

namespace WebApplication_Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly MyDapper _dapper; 
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,MyDapper myDapper)
        {
            _logger = logger;
            _dapper = myDapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet(Name = "GetData")]
        //public DataDto GetData()
        //{
        //    string sql = "";

        //    return _dapper.GetData(sql);
        //}

        [HttpGet("GetData")]
        [ProducesResponseType(typeof(DataDto), StatusCodes.Status200OK)]
        public IActionResult GetData()
        {
            string sql = "select * from sysqan";

            var response = _dapper.GetData(sql);
            return Ok(response);
        }
    }
}