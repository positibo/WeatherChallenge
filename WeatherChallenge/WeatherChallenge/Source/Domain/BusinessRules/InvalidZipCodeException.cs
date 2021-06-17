using System.Net;
using WeatherChallenge.Source.Domain.BusinessRules.Base;

namespace WeatherChallenge.Source.Domain.BusinessRules
{
    public class InvalidZipCodeException : BusinessRulesException
    {
        private const string message = "Business Rules Exception: Invalid zip code.";

        public InvalidZipCodeException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
