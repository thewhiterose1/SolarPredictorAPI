using SolarPredictor.Common.Interface;
using SolarPredictor.Contracts.Responses;

namespace SolarPredictor.Infrastructure.Repository
{
    public class TelemetryRepository : ITelemetryRepository
    {
        public async Task<GenerateTelemetryResponse> GetTelemetryData()
        {
            return new GenerateTelemetryResponse()
            {
                PostCode = "NL452QE"
            };
        }
    }
}