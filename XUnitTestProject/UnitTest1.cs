using asteroidalert.Infrastructure;
using asteroidalert.Repository;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {



        [Fact]
        public void Test1()
        {
            var repo = new NasaNeoWs(new JsonDeserializer()) as IRepositoryNearEarthObjects;
            var f = repo.Get (DateTime.Now, DateTime.Now.AddDays(-7));
            Console.WriteLine(f);
        }
    }
}
