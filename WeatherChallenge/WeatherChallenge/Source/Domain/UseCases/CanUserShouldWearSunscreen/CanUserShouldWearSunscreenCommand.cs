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
            private IWeather dataManagement;

            public CanUserShouldWearSunscreenCommandHandler(IWeather dataManagement) => this.dataManagement = dataManagement;

            public async Task<bool> Handle(CanUserShouldWearSunscreenCommand request, CancellationToken cancellationToken)
            {

                var weatherInfo = await dataManagement.GetWeatherInfo(request.zipCode);
                //  Is UV index above 3 then YES
                if (weatherInfo.Current.UvIndex > 3)
                    return true;

                return false;

            }
        }
    }
}
