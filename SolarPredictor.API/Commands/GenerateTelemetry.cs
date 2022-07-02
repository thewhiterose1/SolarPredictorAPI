using MediatR;
using SolarPredictor.Contracts.Requests;
using SolarPredictor.Common.Interface;
using SolarPredictor.Contracts.Responses;
using System.Net;
using Newtonsoft.Json;

namespace SolarPredictor.API.Commands
{
    // Command 
    public class GenerateTelemetryCommand : IRequest<GenerateTelemetryResponse>
    {
        public GenerateTelemetryRequest GenerateTelemetryRequest { get; set; }
    }

    // Command Handler
    public class GenerateTelemetryCommandHandler : IRequestHandler<GenerateTelemetryCommand, GenerateTelemetryResponse>
    {
        private readonly ITelemetryRepository _repository;
        private readonly IConfiguration _configuration;

        public GenerateTelemetryCommandHandler(ITelemetryRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<GenerateTelemetryResponse> Handle(GenerateTelemetryCommand request, CancellationToken cancellationToken)
        {
            var apiEndpoint = _configuration.GetSection("Solcast.APIEndpoint").Value;
            var builtURL = string.Format
                (
                apiEndpoint, request.GenerateTelemetryRequest.Latitude,
                request.GenerateTelemetryRequest.Longitude,
                request.GenerateTelemetryRequest.Hours,
                _configuration.GetSection("Solcast.AuthorisationToken").Value,
                "json"
                );

            var solCastRequest = WebRequest.Create(builtURL);

            using (var reader = new StreamReader(solCastRequest.GetResponse().GetResponseStream()))
            {
                var myObject = JsonConvert.DeserializeObject<ForecastResponse>(reader.ReadToEnd());
            }

            return null;
        }
    }
}