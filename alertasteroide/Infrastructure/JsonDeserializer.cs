using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace asteroidalert.Infrastructure
{


    public class JsonDeserializer : IJsonDeserializer
    {
        public dynamic Deserialize(string jsonString)
        {
            return JsonConvert.DeserializeObject<ExpandoObject>(jsonString, new ExpandoObjectConverter());
        }
    }
}
