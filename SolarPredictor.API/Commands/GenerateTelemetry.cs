using MediatR;
using SolarPredictor.Contracts.Requests;
using SolarPredictor.Common.Interface;
using SolarPredictor.Contracts.Responses;

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
            return await _repository.GetTelemetryData();
        }
    }
}