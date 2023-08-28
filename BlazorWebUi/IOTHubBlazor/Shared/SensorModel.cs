
namespace IOTHubBlazor.Shared
{
    public enum SensorTypeEnum
    {
        
        Temperature = 0,
        Humidity = 1,
        Light = 2,
    }

    public class SensorModel
    {
        public Guid SensorId { get; set; }
        public string SensorName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public SensorTypeEnum Type { get; set; }
        public bool Enabled { get; set; } = false;
        public string Value { get; set; } = string.Empty;
    }
}
