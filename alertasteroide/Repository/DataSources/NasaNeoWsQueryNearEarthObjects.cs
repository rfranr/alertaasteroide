using System;
using System.Globalization;

namespace asteroidalert.Repository
{
    public class NasaNeoWsQueryNearEarthObjects : IQueryNearEarthObjects
    {
        private readonly dynamic _node;
        private readonly CultureInfo _provider;
        public NasaNeoWsQueryNearEarthObjects(dynamic node)
        {
            _node = node;
            _provider = new CultureInfo("en-US");
        }

        public double estimated_diameter_max { get => _node.estimated_diameter.kilometers.estimated_diameter_max; }
        public double estimated_diameter_min { get => _node.estimated_diameter.kilometers.estimated_diameter_min; }
        public bool is_potentially_hazardous_asteroid { get => (bool)_node.is_potentially_hazardous_asteroid; }
        public double estimated_diameter { get => (estimated_diameter_max + estimated_diameter_min) / 2; }
        public DateTime date
        {
            get
            {
                return DateTime.Parse(_node.close_approach_data[0]?.close_approach_date, _provider, DateTimeStyles.NoCurrentDateDefault);
            }
        }
        public decimal kilometers_per_hour { 
            get {
                string value = _node.close_approach_data[0]?.relative_velocity.kilometers_per_hour;
                return Convert.ToDecimal(value,_provider);
            } 
        } 
        public string orbiting_body { get => _node.close_approach_data[0]?.orbiting_body; }
        public string name { get => _node.name; }
    }
}
