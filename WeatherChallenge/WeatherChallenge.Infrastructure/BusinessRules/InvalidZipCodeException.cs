using System.Net;
using WeatherChallenge.Infrastructure.BusinessRules.Base;

namespace WeatherChallenge.Infrastructure.BusinessRules
{
    public class InvalidZipCodeException : BusinessRulesException
    {
        private const string message = "Business Rules Exception: Invalid zip code.";

        public InvalidZipCodeException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
