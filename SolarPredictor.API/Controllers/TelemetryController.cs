using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolarPredictor.API.Commands;
using SolarPredictor.Contracts.Requests;

namespace SolarPredictor.API.Controllers
{
    public class TelemetryController : Controller
    {
        private readonly IMediator _mediator;

        public TelemetryController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost("GenerateTelemetry")]
        public async Task<ActionResult> GenerateTelemetry(GenerateTelemetryRequest var) {
                var result = await _mediator.Send(new GenerateTelemetryCommand() { 
                    GenerateTelemetryRequest = var 
                });

                return Ok(result);
        }
    }
}