

namespace SolarPredictor.Contracts.Responses
{
    public class ForecastResponse
    {
        public IEnumerable<SolCastResponse> Forecasts { get; set; }
    }
}
