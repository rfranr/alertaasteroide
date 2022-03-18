using asteroidalert.Infrastructure;
using System;
using System.Collections.Generic;

namespace asteroidalert.Repository
{
    public interface IRepositoryNearEarthObjects
    {
        /// <summary>
        /// Near earth Asteroid information
        /// </summary>
        /// <param name="start_date">Starting date for asteroid search</param>
        /// <param name="end_date">Ending date for asteroid search</param>
        /// <returns></returns>
        public IEnumerable<IQueryNearEarthObjects> Get(DateTime start_date, DateTime end_date);
    }
}