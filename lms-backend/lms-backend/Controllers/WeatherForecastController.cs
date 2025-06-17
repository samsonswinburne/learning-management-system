using Isopoh.Cryptography.Argon2;
using lms_backend.Models;
using lms_backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MongoDB.Bson;
using System.Security.Cryptography;
using System.Text;

namespace lms_backend.Controllers
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

        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        private readonly MongoDBService _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MongoDBService db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost(Name ="Temporary create student")]
        public async Task Create()
        {
            
            var password = Argon2.Hash("password");
            Student student = new Student("tuttelloise@gmail.com", password, null, "Elloise", "Tutt", new DateOnly(2007, 02, 11), false, null, new ObjectId("685147a5e77502bf5c78c9ca"));
            await _db.CreateStudentAsync(student);
            
        }
        [HttpPost("testlogin", Name = "test login with hash")]
        public async Task<bool> TestLogin([FromBody] string password)
        {
            Student student = await _db.FetchStudentByEmailAsync("dryandbored@gmail.com");
            return Argon2.Verify(student.Password, password);
        }

        [HttpPost("createschool", Name = "create school test")]
        public async Task CreateSchool()
        {
            School school = new School("Samsons School", null);
           await _db.CreateSchoolAsync(school);
        }
    }
}
