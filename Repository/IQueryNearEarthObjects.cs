namespace asteroidalert.Repository
{
    /// <summary>
    /// Return information of one NearEarthObject
    /// </summary>
    public interface IQueryNearEarthObjects
    {
        public bool is_potentially_hazardous_asteroid { get; }

        public double estimated_diameter { get; }

        public double estimated_diameter_min { get; }
    }


}