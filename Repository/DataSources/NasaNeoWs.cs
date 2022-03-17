using asteroidalert.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace asteroidalert.Repository
{

    public class NasaNeoWs : IRepositoryNearEarthObjects
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

        private dynamic Feed(DateTime start_date, DateTime end_date)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("feed", Method.Get);
            request.AddParameter("start_date", start_date.ToString("yyyy-MM-dd"));
            request.AddParameter("end_date", end_date.ToString("yyyy-MM-dd"));
            request.AddParameter("api_key", ApiKey());

            var restResponse = client.GetAsync(request);


            string content = restResponse.Result.get_Content();

            if (!restResponse.IsCompletedSuccessfully)
            {
                throw new ApplicationException("ERROR GEETING FEED", restResponse.Exception);
            }

            return _jsonDeserializer.Deserialize(content);
        }

        IEnumerable<IQueryNearEarthObjects> IRepositoryNearEarthObjects.Get(DateTime start_date, DateTime end_date)
        {
            var data = Feed(start_date, end_date);

            List<IQueryNearEarthObjects> list = new List<IQueryNearEarthObjects>();

            foreach (KeyValuePair<string,dynamic> near_object in data.near_earth_objects)
            {
                foreach ( var near_object_data in near_object.Value)
                {
                    list.Add(new NasaNeoWsQueryNearEarthObjects(near_object_data));
                }
            }

            return list;
        }
    }
}
