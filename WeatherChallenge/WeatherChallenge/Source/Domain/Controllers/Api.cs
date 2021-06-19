using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.UseCases.CanUserFlyKite;
using WeatherChallenge.Source.Domain.UseCases.CanUserGoOutside;
using WeatherChallenge.Source.Domain.UseCases.CanUserWearSunscreen;

namespace WeatherChallenge.Source.Domain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Api : ControllerBase
    {
        private IMediator mediator;

        public Api(IMediator mediator) => this.mediator = mediator;

        [HttpGet("CanUserFlyKite")]
        public async Task<ActionResult> CanUserFlyKite(string zipCode)
        {
            var result = await mediator.Send(new CanUserFlyKiteCommand(zipCode));

            return Ok(result);
        }

        [HttpGet("CanUserGoOutside")]
        public async Task<ActionResult> CanUserGoOutside(string zipCode)
        {
            var result = await mediator.Send(new CanUserGoOutsideCommand(zipCode));

            return Ok(result);
        }

        [HttpGet("CanUserWearSunscreen")]
        public async Task<ActionResult> CanUserWearSunscreen(string zipCode)
        {
            var result = await mediator.Send(new CanUserWearSunscreenCommand(zipCode));

            return Ok(result);
        }

    }
}
