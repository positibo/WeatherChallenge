﻿using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.BusinessRules;
using WeatherChallenge.Source.Domain.Interfaces;

namespace WeatherChallenge.Source.Domain.UseCases.CanUserFlyKite
{
    public class CanUserFlyKiteCommand : IRequest<bool>
    {
        public string zipCode;

        public CanUserFlyKiteCommand(string zipCode) => this.zipCode = zipCode;

        public class CanUserFlyKiteCommandHandler : IRequestHandler<CanUserFlyKiteCommand, bool>
        {
            private IWeatherStackDataManagement dataManagement;

            public CanUserFlyKiteCommandHandler(IWeatherStackDataManagement dataManagement) => this.dataManagement = dataManagement;

            public async Task<bool> Handle(CanUserFlyKiteCommand request, CancellationToken cancellationToken)
            {

                if (string.IsNullOrEmpty(request.zipCode))
                    throw new InvalidZipCodeException();

                var weatherInfo = await dataManagement.GetWeatherInfo(request.zipCode);
                if (weatherInfo.Current == null)
                    throw new NotFoundException();

                //  Yes if not raining and wind speed over 15
                if (!weatherInfo.Current.WeatherDescriptions.Any(o => o.Contains("rain")) && weatherInfo.Current.WindSpeed > 15)
                    return true;

                return false;

            }
        }
    }
}