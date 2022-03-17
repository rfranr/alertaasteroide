using asteroidalert.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Dynamic;

namespace asteroidalert.Repository
{
    public class NasaNeoWs
    {
        private string _url = "https://api.nasa.gov/neo/rest/v1";

        private readonly IJsonDeserializer _jsonDeserializer;

        public NasaNeoWs(IJsonDeserializer jsonDeserializer)
        {
            _jsonDeserializer = jsonDeserializer;
        }
        private string ApiKey()
        {
            return "wZilILH1fpHBLigptOjOcwPRUjKs8euVH9BleY0Z";
        }

        public dynamic Feed (DateTime start_date, DateTime end_date)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("feed", Method.Get);
            request.AddParameter("start_date", start_date.ToString("yyyy-MM-dd"));
            request.AddParameter("end_date", end_date.ToString("yyyy-MM-dd"));
            request.AddParameter("api_key", ApiKey());

            var restResponse = client.GetAsync( request );
            string content = restResponse.Result.get_Content();

            return _jsonDeserializer.Deserialize(content);
        }
    }
}
