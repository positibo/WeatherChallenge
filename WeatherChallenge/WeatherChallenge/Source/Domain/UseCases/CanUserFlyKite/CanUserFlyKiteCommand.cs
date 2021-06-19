using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Infrastructure;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserFlyKite
{
    public class CanUserFlyKiteCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserFlyKiteCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserFlyKiteCommandHandler : IRequestHandler<CanUserFlyKiteCommand, bool>
        {
            private IWeather weather;

            public CanUserFlyKiteCommandHandler(IWeather weather) => this.weather = weather;

            public async Task<bool> Handle(CanUserFlyKiteCommand request, CancellationToken cancellationToken)
            {

                //  Yes if not raining and wind speed over 15
                if (!await weather.IsItRaining(request.zipCode) && await weather.IsItWindy(request.zipCode))
                    return true;

                return false;

            }
        }
    }
}
