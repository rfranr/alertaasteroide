namespace asteroidalert.Repository
{
    public class NasaNeoWsQueryNearEarthObjects : IQueryNearEarthObjects
    {
        private readonly dynamic _node;
        public NasaNeoWsQueryNearEarthObjects(dynamic node)
        {
            _node = node;
        }

        public double estimated_diameter { get => _node.estimated_diameter.kilometers.estimated_diameter_max; }
        public double estimated_diameter_min { get => _node.estimated_diameter.kilometers.estimated_diameter_min; }
        public bool is_potentially_hazardous_asteroid { get => (bool)_node.is_potentially_hazardous_asteroid; }
    }
}
