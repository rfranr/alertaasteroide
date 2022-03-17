using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asteroidalert.Business;
using asteroidalert.Infrastructure;
using asteroidalert.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace asteroidalert.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertAsteroidController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AlertAsteroidController> _logger;
        private readonly NearEarthObjectBusiness _nearEarthObjectBusines;

        public AlertAsteroidController(ILogger<AlertAsteroidController> logger)
        {
            _logger = logger;
            
            IRepositoryNearEarthObjects repositoryNearEarthObjects = new NasaNeoWs(new JsonDeserializer());
            _nearEarthObjectBusines = new NearEarthObjectBusiness(repositoryNearEarthObjects);

        }

        [HttpGet]
        [Route("Alert")]
        public IEnumerable<AlertAsteroid> Alert(ushort days)
        {
            return _nearEarthObjectBusines.Alert(days);
        }

        [HttpGet]
        [Route("Warning")]
        public IEnumerable<AlertAsteroid> Warning(ushort days)
        {
            return _nearEarthObjectBusines.Warning(days);
        }

    }
}
