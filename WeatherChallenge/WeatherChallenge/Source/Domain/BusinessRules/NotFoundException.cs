using System.Net;
using WeatherChallenge.Source.Domain.BusinessRules.Base;

namespace WeatherChallenge.Source.Domain.BusinessRules
{
    public class NotFoundException : BusinessRulesException
    {
        private const string message = "Business Rules Exception: Data not found.";

        public NotFoundException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
