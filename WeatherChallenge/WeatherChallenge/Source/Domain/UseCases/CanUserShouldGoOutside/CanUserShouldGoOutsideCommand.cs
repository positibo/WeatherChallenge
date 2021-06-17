using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.BusinessRules;
using WeatherChallenge.Source.Domain.Interfaces;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserShouldGoOutside
{
    public class CanUserShouldGoOutsideCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserShouldGoOutsideCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserShouldGoOutsideCommandHandler : IRequestHandler<CanUserShouldGoOutsideCommand, bool>
        {
            private IWeatherStackDataManagement dataManagement;

            public CanUserShouldGoOutsideCommandHandler(IWeatherStackDataManagement dataManagement) => this.dataManagement = dataManagement;

            public async Task<bool> Handle(CanUserShouldGoOutsideCommand request, CancellationToken cancellationToken)
            {

                if (string.IsNullOrEmpty(request.zipCode))
                    throw new InvalidZipCodeException();

                var weatherInfo = await dataManagement.GetWeatherInfo(request.zipCode);
                //  Yes if it’s not raining, no if it’s raining
                if (!weatherInfo.Current.WeatherDescriptions.Any(o => o.Contains("rain")))
                    return true;

                return false;

            }
        }
    }
}
