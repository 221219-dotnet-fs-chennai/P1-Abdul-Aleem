using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BusinessLogic;

namespace Service.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
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

    [HttpGet("Hello")]
    public int[] AGet()
    {
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        return arr;
    }

    //[HttpPost("Login")]
    //public IActionResult post([FromBody] LoginClass loginClass)
    //{
    //    Login login = new Login();

    //    bool res = login.LoginSubmit(loginClass.EmailID, loginClass.Password);

    //    if (res)
    //    {
    //        return Ok();
    //    }
    //    else
    //    {
    //        return NotFound();
    //    }
    //}

}

