using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.UseCases.CanUserFlyKite;
using WeatherChallenge.Source.Domain.UseCases.CanUserShouldGoOutside;
using WeatherChallenge.Source.Domain.UseCases.CanUserShouldWearSunscreen;

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

        [HttpGet("CanUserShouldGoOutside")]
        public async Task<ActionResult> CanUserShouldGoOutside(string zipCode)
        {
            var result = await mediator.Send(new CanUserShouldGoOutsideCommand(zipCode));

            return Ok(result);
        }

        [HttpGet("CanUserShouldWearSunscreen")]
        public async Task<ActionResult> CanUserShouldWearSunscreen(string zipCode)
        {
            var result = await mediator.Send(new CanUserShouldWearSunscreenCommand(zipCode));

            return Ok(result);
        }

    }
}
