using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BoboTech.SecretsManager.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            var mongoClient = new MongoClient("mongodb://admin:<dbpass>@ds062178.mlab.com:62178/encryptedpass");
            var database = mongoClient.GetDatabase("encryptedpass");
            var collection = database.GetCollection<Models.User>(Models.User.CollectionName);
            var user = (await collection.FindAsync(f => f.UserName == "bogdan")).FirstOrDefault();
            return new List<WeatherForecast>{ new WeatherForecast{ DateFormatted = DateTime.Now.ToShortDateString(), TemperatureC = 21, Summary = user?.UserName }};
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
            //     TemperatureC = rng.Next(-20, 55),
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // });
        }

        

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
