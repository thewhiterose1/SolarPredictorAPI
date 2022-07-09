namespace SolarPredictor.Contracts.Responses
{
    public class GenerateTelemetryResponse
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Hours { get; set; }
    }
}