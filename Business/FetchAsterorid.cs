using asteroidalert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asteroidalert.Business
{

    public class NearEarthObject
    {
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }


    public class NearEarthObjectBusiness
    {
        private readonly IRepositoryNearEarthObjects _nearEarthObjects;

        public NearEarthObjectBusiness(IRepositoryNearEarthObjects nearEarthObjects)
        {
            _nearEarthObjects = nearEarthObjects;
        }

        public void Alert(ushort days)
        {
            //var nearObjectsData = _nearEarthObjects.Feed(DateTime.Now, DateTime.Now.AddDays(days));

        }


    }
}
