namespace asteroidalert.Infrastructure
{
    public interface IJsonDeserializer
    {
        public dynamic Deserialize(string jsonString);
    }
}