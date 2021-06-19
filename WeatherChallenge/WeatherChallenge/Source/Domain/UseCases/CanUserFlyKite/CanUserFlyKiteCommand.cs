using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Providers.WeatherStack;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserFlyKite
{
    public class CanUserFlyKiteCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserFlyKiteCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserFlyKiteCommandHandler : IRequestHandler<CanUserFlyKiteCommand, bool>
        {
            private IWeatherStackProvider weatherStackProvider;

            public CanUserFlyKiteCommandHandler(IWeatherStackProvider weatherStackProvider) => this.weatherStackProvider = weatherStackProvider;

            public async Task<bool> Handle(CanUserFlyKiteCommand request, CancellationToken cancellationToken)
            {

                //  Yes if not raining and wind speed over 15
                if (!await weatherStackProvider.IsItRaining(request.zipCode) && await weatherStackProvider.IsItWindy(request.zipCode))
                    return true;

                return false;

            }
        }
    }
}
