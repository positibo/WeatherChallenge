using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Infrastructure;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserShouldWearSunscreen
{
    public class CanUserShouldWearSunscreenCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserShouldWearSunscreenCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserShouldWearSunscreenCommandHandler : IRequestHandler<CanUserShouldWearSunscreenCommand, bool>
        {
            private IWeather weather;

            public CanUserShouldWearSunscreenCommandHandler(IWeather weather) => this.weather = weather;

            public async Task<bool> Handle(CanUserShouldWearSunscreenCommand request, CancellationToken cancellationToken)
            {

                //  Is UV index above 3 then YES
                return await weather.IsHighUV(request.zipCode);

            }
        }
    }
}
