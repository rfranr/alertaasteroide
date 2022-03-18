using System.Collections.Generic;

namespace asteroidalert.Business
{
    public interface INearEarthObjectBusiness
    {
        IList<AlertAsteroid> Alert(ushort days);
        IList<AlertAsteroid> Warning(ushort days);
    }
}