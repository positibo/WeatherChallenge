using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Infrastructure;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserShouldGoOutside
{
    public class CanUserShouldGoOutsideCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserShouldGoOutsideCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserShouldGoOutsideCommandHandler : IRequestHandler<CanUserShouldGoOutsideCommand, bool>
        {
            private IWeather weather;

            public CanUserShouldGoOutsideCommandHandler(IWeather weather) => this.weather = weather;

            public async Task<bool> Handle(CanUserShouldGoOutsideCommand request, CancellationToken cancellationToken)
            {

                //  Yes if it’s not raining, no if it’s raining
                return await weather.IsItRaining(request.zipCode);

            }
        }
    }
}
