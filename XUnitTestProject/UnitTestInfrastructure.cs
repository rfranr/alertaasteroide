using asteroidalert.Business;
using asteroidalert.Infrastructure;
using asteroidalert.Repository;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTestBusinessLayer
    {

        [Fact]
        public void TestFetchAsteroid_When_Sort_Expect_Dynamic()
        {
            IRepositoryNearEarthObjects repositoryNearEarthObjects = new NasaNeoWs(new JsonDeserializer());

            var nearEarthObjectBusiness = new NearEarthObjectBusiness(repositoryNearEarthObjects);

            var response = nearEarthObjectBusiness.Alert(7);

            Assert.Equal("bar", response[0].Nombre);
        }
    }
}
