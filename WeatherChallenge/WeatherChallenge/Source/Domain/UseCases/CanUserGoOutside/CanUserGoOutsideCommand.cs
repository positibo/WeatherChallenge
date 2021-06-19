using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Providers.WeatherStack;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserGoOutside
{
    public class CanUserGoOutsideCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserGoOutsideCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserShouldGoOutsideCommandHandler : IRequestHandler<CanUserGoOutsideCommand, bool>
        {
            private IWeatherStackProvider weatherStackProvider;

            public CanUserShouldGoOutsideCommandHandler(IWeatherStackProvider weatherStackProvider) => this.weatherStackProvider = weatherStackProvider;

            public async Task<bool> Handle(CanUserGoOutsideCommand request, CancellationToken cancellationToken)
            {

                //  Yes if it’s not raining, no if it’s raining
                return await weatherStackProvider.IsItRaining(request.zipCode);

            }
        }
    }
}
