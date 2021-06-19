using System.Net;
using WeatherChallenge.Infrastructure.BusinessRules.Base;

namespace WeatherChallenge.Infrastructure.BusinessRules
{
    public class NotFoundException : BusinessRulesException
    {
        private const string message = "Business Rules Exception: Data not found.";

        public NotFoundException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
