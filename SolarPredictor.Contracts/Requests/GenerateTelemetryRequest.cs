namespace SolarPredictor.Contracts.Requests
{
    public class GenerateTelemetryRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Hours { get; set; }
    }
}