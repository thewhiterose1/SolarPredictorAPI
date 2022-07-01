using SolarPredictor.Contracts.Responses;

namespace SolarPredictor.Common.Interface
{
    public interface ITelemetryRepository
    {
        public Task<GenerateTelemetryResponse> GetTelemetryData();
    }
}
