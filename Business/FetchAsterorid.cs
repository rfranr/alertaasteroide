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

    public interface IRepository
    {

    }

    public class NearEarthObjectBusiness
    {

        IRepository nearEarthObject;

        public void NearEarthObject(NearEarthObject NearEarthObject)
        {
            //NearEarthObject.end_date;
            //NearEarthObject.start_date;



        }
    }
}
