using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Providers.WeatherStack;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserWearSunscreen
{
    public class CanUserWearSunscreenCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserWearSunscreenCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserShouldWearSunscreenCommandHandler : IRequestHandler<CanUserWearSunscreenCommand, bool>
        {
            private IWeatherStackProvider weatherStackProvider;

            public CanUserShouldWearSunscreenCommandHandler(IWeatherStackProvider weatherStackProvider) => this.weatherStackProvider = weatherStackProvider;

            public async Task<bool> Handle(CanUserWearSunscreenCommand request, CancellationToken cancellationToken)
            {

                //  Is UV index above 3 then YES
                return await weatherStackProvider.IsHighUV(request.zipCode);

            }
        }
    }
}
