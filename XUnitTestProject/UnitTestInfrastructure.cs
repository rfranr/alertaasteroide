using asteroidalert.Business;
using asteroidalert.Infrastructure;
using asteroidalert.Repository;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTestRepository
    {

        [Fact]
        public void TestFetchAsteroid_When_Sort_Expect_Response()
        {
            IRepositoryNearEarthObjects repositoryNearEarthObjects = new NasaNeoWs(new JsonDeserializer());

            var nearEarthObjectBusiness = new NearEarthObjectBusiness(repositoryNearEarthObjects);

            var response = nearEarthObjectBusiness.Alert(1);

            Assert.NotEmpty(response[0].Nombre);
        }



    }
}
