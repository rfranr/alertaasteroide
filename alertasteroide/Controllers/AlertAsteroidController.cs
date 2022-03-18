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
        private readonly ILogger<AlertAsteroidController> _logger;
        private readonly INearEarthObjectBusiness _nearEarthObjectBusines;

        public AlertAsteroidController(ILogger<AlertAsteroidController> logger, INearEarthObjectBusiness nearEarthObjectBusiness)
        {
            _logger = logger;
            _nearEarthObjectBusines = nearEarthObjectBusiness;
        }

        [HttpGet]
        [Route("Alert")]
        public IEnumerable<AlertAsteroid> Alert(ushort days)
        {
            _logger.LogInformation($"{days}");

            return _nearEarthObjectBusines.Alert(days);
        }

        [HttpGet]
        [Route("Warning")]
        public IEnumerable<AlertAsteroid> Warning(ushort days)
        {
            _logger.LogInformation($"{days}");

            return _nearEarthObjectBusines.Warning(days);
        }

    }
}
