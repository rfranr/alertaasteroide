using System;

namespace asteroidalert.Repository
{
    /// <summary>
    /// Return information of one NearEarthObject
    /// </summary>
    public interface IQueryNearEarthObjects
    {
        public bool is_potentially_hazardous_asteroid { get; }
        public double estimated_diameter_max { get; }
        public double estimated_diameter_min { get; }
        public double estimated_diameter { get; }
        public DateTime date { get; }
        public decimal kilometers_per_hour { get; }
        public string orbiting_body { get; }
        public string name { get; }
    }


}