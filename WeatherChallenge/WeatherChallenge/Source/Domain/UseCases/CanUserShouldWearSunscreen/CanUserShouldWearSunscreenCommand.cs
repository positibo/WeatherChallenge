using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.BusinessRules;
using WeatherChallenge.Source.Domain.Interfaces;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserShouldWearSunscreen
{
    public class CanUserShouldWearSunscreenCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserShouldWearSunscreenCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserShouldWearSunscreenCommandHandler : IRequestHandler<CanUserShouldWearSunscreenCommand, bool>
        {
            private IWeatherStackDataManagement dataManagement;

            public CanUserShouldWearSunscreenCommandHandler(IWeatherStackDataManagement dataManagement) => this.dataManagement = dataManagement;

            public async Task<bool> Handle(CanUserShouldWearSunscreenCommand request, CancellationToken cancellationToken)
            {

                if (string.IsNullOrEmpty(request.zipCode))
                    throw new InvalidZipCodeException();

                var weatherInfo = await dataManagement.GetWeatherInfo(request.zipCode);
                //  Is UV index above 3 then YES
                if (weatherInfo.Current.UvIndex > 3)
                    return true;

                return false;

            }
        }
    }
}
