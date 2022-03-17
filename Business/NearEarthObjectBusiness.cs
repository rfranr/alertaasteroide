using asteroidalert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asteroidalert.Business
{


    public class NearEarthObjectBusiness : INearEarthObjectBusiness
    {
        private readonly IRepositoryNearEarthObjects _nearEarthObjects;
        private readonly int _showOnly = 3;

        public NearEarthObjectBusiness(IRepositoryNearEarthObjects nearEarthObjects)
        {
            _nearEarthObjects = nearEarthObjects;
        }

        public IList<AlertAsteroid> Alert(ushort days)
        {
            IEnumerable<IQueryNearEarthObjects> nearObjectsData = _nearEarthObjects.Get(DateTime.Now, DateTime.Now.AddDays(days));

            return Project(Query(nearObjectsData, true, _showOnly));
        }

        public IList<AlertAsteroid> Warning(ushort days)
        {
            IEnumerable<IQueryNearEarthObjects> nearObjectsData = _nearEarthObjects.Get(DateTime.Now, DateTime.Now.AddDays(days));

            return Project(Query(nearObjectsData, false, _showOnly));
        }

        private IList<IQueryNearEarthObjects> Query(IEnumerable<IQueryNearEarthObjects> nearObjectsData, bool ishazardous, int take)
        {
            return nearObjectsData
                .Where(x => x.is_potentially_hazardous_asteroid == ishazardous)
                .OrderBy(x => x.estimated_diameter_max)
                .Take(take)
                .ToList();
        }

        private IList<AlertAsteroid> Project(IList<IQueryNearEarthObjects> query)
        {
            return query
                .Select(s => new AlertAsteroid()
                {
                    Diametro = s.estimated_diameter,
                    Fecha = s.date,
                    Nombre = s.name,
                    Planeta = s.orbiting_body,
                    Velocidad = s.kilometers_per_hour
                })
                .ToList();
        }

    }
}
