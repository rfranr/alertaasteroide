using asteroidalert.Business;
using asteroidalert.Infrastructure;
using asteroidalert.Repository;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTestInfrastructure
    {

        [Fact]
        public void TestJsonDeserializer_When_Alert_Expect_Data()
        {
            var JsonDeserializer = new JsonDeserializer();

            var data = JsonDeserializer.Deserialize("{\"foo\":\"bar\"}");

            Assert.Equal("bar", data.foo);
        }
    }
}
